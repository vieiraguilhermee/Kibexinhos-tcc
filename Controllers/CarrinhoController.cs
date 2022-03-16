using Microsoft.AspNetCore.Mvc;
using Kibexinhos.Data;
using Kibexinhos.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace Kibexinhos.Controllers
{
    [Route("Carrinho")]
    public class CarrinhoController : ControllerBase
    {
        
        [HttpGet]
        [Route("")]
        [Authorize]
        public async Task<ActionResult<List<Carrinho>>> Carrinho([FromServices] DataContext context,
                                                                [FromBody] Carrinho carrinho)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                string test = identity.FindFirst("ClienteId").Value;
            }

            var carrinhodb = await context
                                        .Carrinho
                                        .Include(x => x.Produto)
                                        .ThenInclude(y => y.ImageProduto.Take(1))
                                        .AsNoTracking()
                                        .Where(x => x.ClienteId == carrinho.ClienteId)
                                        .ToListAsync();
            return Ok(carrinhodb);
        }

        
    }
}