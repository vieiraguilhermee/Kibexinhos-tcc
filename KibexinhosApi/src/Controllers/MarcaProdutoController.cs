using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Kibexinhos.Data;
using Kibexinhos.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("Marca")]
public class MarcaProdutoController : ControllerBase
{
    
    [HttpGet]
    [Route("")]
    public async Task<ActionResult<MarcaProduto>> GetMarcaPorPet([FromServices] DataContext context)
    {
        try
        {
            var marcas = await context
                                    .MarcaProduto
                                    .AsNoTracking()
                                    .ToListAsync();

            return Ok(marcas);
        }
        catch (System.Exception)
        {
            return BadRequest( new { Message = "Não foi possível fazer a consulta" } );
        }
        
    }


}