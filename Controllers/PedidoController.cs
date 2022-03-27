using System.Security.Claims;
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
        pedido.CriadoEm = DateTime.Now;
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
            //context.Entry(x.Produto.Estoque).CurrentValues.SetValues(3);
            x.Produto!.Estoque -= x.Quantidade;
            context.Entry<Produto>(x.Produto).State = EntityState.Modified;
            pedidos.Add(item);
        }
        context.PedidoItem.AddRange(pedidos);

        context.Carrinho.RemoveRange(carrinhodb);
        await context.SaveChangesAsync();

        return Ok();
                
    }


}