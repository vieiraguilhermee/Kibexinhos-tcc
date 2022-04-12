using System.Security.Claims;
using System.Threading.Tasks;
using Kibexinhos.Data;
using Kibexinhos.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("tipopagamento")]
public class TipoPagamentoController : ControllerBase
{
    
    [HttpGet]
    [Authorize]
    [Route("")]
    public async Task<ActionResult<Cupom>> FormasPagamento([FromServices] DataContext context)
    {
        try
        {
            var formas = await context
                                    .TipoPagamento
                                    .AsNoTracking()
                                    .ToListAsync();
        
            return Ok(formas);
        }
        catch
        {
            return BadRequest( new { Message = "Não foi possível fazer a consulta" } );
        }
               
    }


}