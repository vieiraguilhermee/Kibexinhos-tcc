using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Kibexinhos.Data;
using Kibexinhos.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            int claimid = 0;
            if (identity != null)
            {
                claimid = Int32.Parse(identity.FindFirst("ClienteId")!.Value);
            }
            else 
                return BadRequest( new { Message = "Usuário não logado"} );

            var carrinhodb = await context
                                        .Carrinho
                                        .Include(x => x.Produto)
                                        .AsNoTracking()
                                        .Where(x => x.ClienteId == claimid)
                                        .ToListAsync();

            if ((carrinhodb.Where(x => x.Produto!.Ativo == false)).Any())
                return BadRequest( new { Message = "Um ou mais produtos estão desativados"});


            pedido.ClienteId = claimid;
            pedido.CriadoEm = DateTime.UtcNow;
            pedido.Status = "Em andamento";
            
            context.Pedido.Add(pedido);
            await context.SaveChangesAsync();


            
            
            List<PedidoItem> pedidos = new List<PedidoItem>();
            foreach (var x in carrinhodb)
            {
                if (x.Produto!.Estoque < x.Quantidade)
                    return BadRequest( new { Message = "Não há estoque suficiente para atender a demanda do produto(s)"});

                PedidoItem item = new PedidoItem();
                item.PedidoId = pedido.Id;
                item.ProdutoId = x.ProdutoId;
                item.PrecoUnit = x.Produto!.PrecoDescontado;
                item.Quantidade = x.Quantidade;
                x.Produto!.Estoque -= x.Quantidade;
                context.Entry<Produto>(x.Produto).State = EntityState.Modified;
                pedidos.Add(item);
            }
            context.PedidoItem.AddRange(pedidos);

            context.Carrinho.RemoveRange(carrinhodb);
            await context.SaveChangesAsync();

            return Ok();
        }
        catch
        {
            return BadRequest( new { Message  = "Erro ao fazer pedido"});
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

            if (clienteid.Length != 0)
                    clientes = clientes.Where(y => clienteid.Contains(y.Id));
            if (nome.Length != 0)
                    clientes = clientes.Where(y => nome.Contains(y.NomeCliente));

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
            return BadRequest( new { Message = "Não foi possível fazer a consulta" } );
        }

        
    }
}