using System.Security.Claims;
using Kibexinhos.Data;
using Kibexinhos.Models;
using Kibexinhos.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kibexinhos.Controllers
{
    [Route("Cliente")]
    public class ClienteController : ControllerBase
    {
        [HttpPost]
        [Route("Criar")]
        [AllowAnonymous]
        public async Task<ActionResult<Cliente>> Criar([FromServices] DataContext context,
                                                        [FromBody] Cliente cliente)
        {
            if (!ModelState.IsValid)
                return BadRequest( new { Message = "Dados incorretos"});

            try
            {
                var clientedb = await context
                                            .Cliente
                                            .AsNoTracking()
                                            .Where(x => x.Email == cliente.Email)
                                            .FirstOrDefaultAsync();
                if (clientedb != null)
                    return BadRequest( new { Message = "E-mail já cadastrado"});

                context.Cliente.Add(cliente);
                await context.SaveChangesAsync();
                return Ok();
            }
            catch 
            {
                return BadRequest( new { Message  = "Não foi possível criar um usuário"});
            }


        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> Autenticar([FromServices] DataContext context,
                                                            [FromBody] Cliente cliente)
        {
            var clientedb = await context
                                        .Cliente
                                        .AsNoTracking()
                                        .Where(x => x.Email == cliente.Email && x.Senha == cliente.Senha)
                                        .FirstOrDefaultAsync();
            
            if (clientedb == null)
                return NotFound(new { Message = "Usuário ou senha inválidos" });

            var token = TokenService.GenerateToken(clientedb);
            return new
            {
                clientedb, 
                token = token
            };
        }
    }
}
