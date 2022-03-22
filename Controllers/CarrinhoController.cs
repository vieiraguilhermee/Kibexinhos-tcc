using Microsoft.AspNetCore.Mvc;
using Kibexinhos.Data;
using Kibexinhos.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using System.Net.Mime;

namespace Kibexinhos.Controllers
{
    [Route("Carrinho")]
    public class CarrinhoController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        [Authorize]
        public async Task<ActionResult<List<Carrinho>>> Carrinho([FromServices] DataContext context)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
                int claimid = 0;
                if (identity != null)
                    claimid = Int32.Parse(identity.FindFirst("ClienteId")!.Value);
                else 
                    return NotFound( new { Message = "Usuário não está logado" } );

            var carrinhodb = await context
                                        .Carrinho
                                        .Include(x => x.Produto)
                                        .ThenInclude(y => y!.ImageProduto!.Take(1))
                                        .AsNoTracking()
                                        .Where(x => x.ClienteId == claimid)
                                        .ToListAsync();
            return Ok(carrinhodb);
        }

        [HttpPost]
        [Route("adicionar")]
        [Authorize]
        public async Task<ActionResult<Carrinho>> AdicionarItem([FromServices] DataContext context,
                                                                [FromBody] Carrinho carrinho)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                int claimid = 0;
                if (identity != null)
                    claimid = Int32.Parse(identity.FindFirst("ClienteId")!.Value);
                else
                    return NotFound( new { Message = "Usuário não está logado" } );


                var carrinhoitemdb = await context
                                            .Carrinho
                                            .AsNoTracking()
                                            .Where(x => x.ProdutoId == carrinho.ProdutoId && x.ClienteId == claimid)
                                            .FirstOrDefaultAsync();
                if (carrinhoitemdb != null)
                    return BadRequest( new { Message = "Produto já cadastrado no carrinho" });
                
                carrinho.ClienteId = claimid;
                carrinho.Quantidade = 1;
                context.Carrinho.Add(carrinho);
                await context.SaveChangesAsync();
                return Ok();
            }
            catch 
            {
                return BadRequest(new { Message = "Não foi possível adicionar item ao carrinho"} );
            }
        }

        [HttpDelete]
        [Route("remover/{prodId:int}")]
        [Authorize]
        public async Task<ActionResult<Carrinho>> RemoverItem([FromServices] DataContext context,
                                                              int prodId)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            int claimid = 0;
            if (identity != null)
                claimid = Int32.Parse(identity.FindFirst("ClienteId")!.Value);
            else
                return NotFound( new { Message = "Usuário não está logado" } );

            var carrinhoitemdb = await context
                                            .Carrinho
                                            .FirstOrDefaultAsync(x => x.ProdutoId == prodId && x.ClienteId == claimid);
            if (carrinhoitemdb == null)
                return NotFound(new { Message = "Item não encontrado" }); 

            try
            {
                context.Carrinho.Remove(carrinhoitemdb);
                await context.SaveChangesAsync();
                return Ok();
            }
            catch 
            {
                return BadRequest(new { Message = "Não foi possível remover o item" });
            }
        }

        [HttpPatch]
        [Route("atualizar")]
        [Authorize]
        public async Task<ActionResult<Carrinho>> AtualizarItem([FromServices] DataContext context,
                                                                [FromBody] Carrinho carrinho)
        {
            try
            {
                context.Entry<Carrinho>(carrinho).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return Ok();
            }
            catch (DbUpdateConcurrencyException) 
            {
                return BadRequest( new { Message = "Não foi possível atualizar a quantidade " });
            }

            
        }

        
    }
}