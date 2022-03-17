using System.Security.Claims;
using Kibexinhos.Data;
using Kibexinhos.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("Cupom")]
public class CupomController : ControllerBase
{
    
    [HttpGet]
    [Authorize]
    [Route("validar")]
    public async Task<ActionResult<Cupom>> ValidarCupom([FromRoute] string cupom,
                                                        [FromServices] DataContext context)
    {
        var identity = HttpContext.User.Identity as ClaimsIdentity;
        int claimid = 0;
        if (identity != null)
        {
            claimid = Int32.Parse(identity.FindFirst("ClienteId")!.Value);
        }

        var hoje = DateTime.Now.AddDays(-7);

        var discount = await context
                                    .Cupom
                                    .Include(x => x.Pedido!)
                                    //.Where(x => x.Pedido!.Any(y => y.ClienteId == claimid))
                                    .AsNoTracking()
                                    .Where(x => x.Cupoom == cupom 
                                                                    && x.Pedido!.Any(y => y.ClienteId == claimid) 
                                                                    && x.CriadoEm < x.CriadoEm.AddDays(7))
                                    .FirstOrDefaultAsync();
        if (discount == null)
            return NotFound(new { Message = "Cupom já utilizado, expirado ou inexistente" });

        return Ok(new { Message = "Cupom válido"});

                        
                
    }


}