using Kibexinhos.Controllers;
using Kibexinhos.Data;
using Kibexinhos.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

[Route("pedido")]
public class PedidoController : ControllerBase
{

    [HttpPost]
    [Authorize]
    [Route("checkout")]
    public async Task<ActionResult<Cupom>> Checkout([FromServices] DataContext context,
                                                    [FromBody] Pedido pedido)
    {
        try
        {
            double tot = 0;
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            int claimid = 0;
            if (identity != null)
            {
                claimid = Int32.Parse(identity.FindFirst("ClienteId")!.Value);
            }
            else
                return BadRequest(new { Message = "Usuário não logado" });

            var carrinhodb = await context
                                        .Carrinho
                                        .Include(x => x.Produto)
                                        .AsNoTracking()
                                        .Where(x => x.ClienteId == claimid)
                                        .ToListAsync();

            if ((carrinhodb.Where(x => x.Produto!.Ativo == false)).Any())
                return BadRequest(new { Message = "Um ou mais produtos estão desativados" });


            pedido.ClienteId = claimid;
            pedido.CriadoEm = DateTime.UtcNow;
            pedido.Status = "Em andamento";
            

            context.Pedido.Add(pedido);
            await context.SaveChangesAsync();




            List<PedidoItem> pedidos = new List<PedidoItem>();
            foreach (var x in carrinhodb)
            {
                if (x.Produto!.Estoque < x.Quantidade)
                    return BadRequest(new { Message = "Não há estoque suficiente para atender a demanda do produto(s)" });

                PedidoItem item = new PedidoItem();
                item.PedidoId = pedido.Id;
                item.ProdutoId = x.ProdutoId;
                item.PrecoUnit = x.Produto!.PrecoDescontado;
                item.Quantidade = x.Quantidade;
                x.Produto!.Estoque -= x.Quantidade;
                context.Entry<Produto>(x.Produto).State = EntityState.Modified;
                pedidos.Add(item);
                tot += item.Quantidade * item.PrecoUnit;
            }
            context.PedidoItem.AddRange(pedidos);

            context.Carrinho.RemoveRange(carrinhodb);
            pedido.Total = tot;
            await context.SaveChangesAsync();

            pedido.PedidoItem = pedidos;

            var cliente = await context
                                    .Cliente
                                    .AsNoTracking()
                                    .Where(x => x.Id == pedido.ClienteId)
                                    .FirstOrDefaultAsync();

            await EmailProvider.SendEmail(pedido, cliente);

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(new { Message = $"Erro ao fazer pedido: {ex}" });
        }


    }

    [HttpGet]
    [Route("dashboard")]
    public async Task<ActionResult<Cupom>> Dashboard([FromServices] DataContext context,
                                                     [FromQuery] int[] clienteid,
                                                     [FromQuery] string[] nome,
                                                     [FromQuery] int[] pedidoid,
                                                     [FromQuery] DateTime? datainicio = null,
                                                     [FromQuery] DateTime? datafinal = null)
    {
        try
        {
            IEnumerable<Cliente> clientes = await context
                                        .Cliente
                                        .AsNoTracking()
                                        .ToListAsync();

            var pedidin = new Pedido();

            if (clienteid.Length != 0)
                clientes = clientes.Where(y => clienteid.Contains(y.Id));
            if (nome.Length != 0)
                clientes = clientes.Where(y => nome.Contains(y.NomeCliente));

            foreach (var item in clientes)
            {
                item.Senha = "";
            }

            IEnumerable<Pedido> pedidos = await context
                                        .Pedido
                                        .AsNoTracking()
                                        .ToListAsync();

            if (pedidoid.Length != 0)
                pedidos = pedidos.Where(y => pedidoid.Contains(y.Id));
            if (datainicio != null)
                pedidos = pedidos.Where(y => y.CriadoEm >= datainicio);
            if (datafinal != null)
                pedidos = pedidos.Where(y => y.CriadoEm <= datafinal);


            var ids = await context
                                    .PedidoItem
                                    .GroupBy(x => x.ProdutoId)
                                    .Select(x => new
                                    {
                                        ProdutoId = x.Key,
                                        Quantidade = x.Sum(y => y.Quantidade)
                                    })
                                    .OrderByDescending(x => x.Quantidade)
                                    .Select(x => x.ProdutoId)
                                    .ToArrayAsync();

            var maisvendidos = await context
                                        .Produto
                                        .AsNoTracking()
                                        .Where(y => ids.Contains(y.Id))
                                        .ToListAsync();

            return Ok
            (
                new
                {
                    clientes,
                    pedidos,
                    maisvendidos
                }
            );
        }
        catch
        {
            return BadRequest(new { Message = "Não foi possível fazer a consulta" });
        }


    }
}