using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Kibexinhos.Data;
using Kibexinhos.Models;
using Kibexinhos.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Kibexinhos.Controllers
{
    [Route("cliente")]
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
                return BadRequest( new { Message  = "Erro ao criar usuário"});
            }


        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> Autenticar([FromServices] DataContext context,
                                                            [FromBody] Cliente cliente)
        {
            try
            {
                var clientedb = await context
                                            .Cliente
                                            .AsNoTracking()
                                            .Where(x => x.Email == cliente.Email && x.Senha == cliente.Senha)
                                            .FirstOrDefaultAsync();
                
                if (clientedb == null)
                    return NotFound(new { Message = "Usuário ou senha inválidos" });

                var token = TokenService.GenerateToken(clientedb);
                var refreshToken = TokenService.GenerateRefreshToken();
                TokenService.SaveRefreshToken((clientedb.Id).ToString(), refreshToken);
                clientedb.Senha = "";

                return new
                {
                    user = clientedb, 
                    token = token,
                    refreshToken = refreshToken
                };
            }
            catch
            {
                return BadRequest( new { Message  = "Erro ao autenticar"});
            }

            
        }

        [HttpPost]
        [Route("refresh")]
        public IActionResult Refresh([FromHeader] string token, [FromHeader] string refresh)
        {
            try
            {
                var principal = TokenService.GetPrincipalFromExpiredToken(token);
                var username = principal.FindFirst("ClienteId")!.Value;
                var savedRefreshToken = TokenService.GetRefreshToken(username);
                if (savedRefreshToken != refresh)
                    throw new SecurityTokenException("Refresh Token inválido");

                var newJwtToken = TokenService.GenerateToken(principal.Claims);
                var newRefreshToken = TokenService.GenerateRefreshToken();
                TokenService.DeleteRefreshToken(username, refresh);
                TokenService.SaveRefreshToken(username, newRefreshToken);

                return new ObjectResult(new 
                {
                    token = newJwtToken,
                    refreshToken = newRefreshToken
                });
            }
            catch 
            {
                return BadRequest( new { Message  = "Erro ao atualizar token"});
            }

            
        }

    }
}
