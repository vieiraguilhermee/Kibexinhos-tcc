using Kibexinhos.Configuration;
using Kibexinhos.Controllers;
using Kibexinhos.Data;
using Kibexinhos.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Security.Claims;

[Route("pedido")]
public class PedidoController : ControllerBase
{
    private SendGridSettings _sendGridSettings;

    public PedidoController(IOptions<SendGridSettings> sendGridSettings)
    {
        _sendGridSettings = sendGridSettings.Value;
    }

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
                                        .ThenInclude(x => x!.ImageProduto!.Take(1))
                                        .AsNoTracking()
                                        .Where(x => x.ClienteId == claimid)
                                        .ToListAsync();

            List<string> imagens = new List<string>();

            foreach (var item in carrinhodb)
            {

            }

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

                imagens.Add(x.Produto.ImageProduto!.Select(x => x.Imagem).FirstOrDefault()!);
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

            await EmailProvider.SendEmail(pedido, cliente!, imagens, _sendGridSettings.ApiKey);

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(new { Message = $"Erro ao fazer pedido: {ex}" });
        }


    }

    [HttpGet]
    [Route("dashboard")]
    public async Task<ActionResult<Pedido>> Dashboard([FromServices] DataContext context,
                                                     [FromQuery] int clienteid)
    {
        try
        {

            IEnumerable<Pedido> pedidos = await context
                                        .Pedido
                                        .Where(x => x.ClienteId == clienteid)
                                        .AsNoTracking()
                                        .ToListAsync();

            return Ok(pedidos);
        }
        catch
        {
            return BadRequest(new { Message = "Não foi possível fazer a consulta" });
        }


    }

    [HttpGet]
    [Route("teste")]
    public async Task<ActionResult<Cupom>> Teste([FromServices] DataContext context,
                                                [FromQuery] int ident = 18)
    {
        var cliente = await context
                                    .Cliente
                                    .ToListAsync();
        return Ok(cliente);
    }
}