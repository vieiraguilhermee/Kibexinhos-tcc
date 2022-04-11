using System.Security.Claims;
using Kibexinhos.Data;
using Kibexinhos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("produto")]
public class ProdutoController : ControllerBase
{
    [HttpGet]
    [Route("tipopet/{pet:int}")]
    public async Task<ActionResult<List<Produto>>> GetPorTipoPET(
            [FromServices] DataContext context,
            [FromRoute] int pet,
            [FromQuery] int tipo = -1,
            [FromQuery] string linha = "",
            [FromQuery] string porte = "",
            [FromQuery] string idade = "",
            [FromQuery] int ordem = -1,
            [FromQuery] int marca = -1,
            [FromQuery] double max = 0,
            [FromQuery] double min = -1,
            [FromQuery] int pagina = 1)
    {
        try
        {
            IEnumerable<Produto> produtos = await context
                                    .Produto
                                    .Include(x => x.ImageProduto!.Take(1))
                                    .AsNoTracking()
                                    .Where(x => x.PetId == pet)
                                    .Skip((pagina - 1) * 12)
                                    .Take(12)
                                    .ToListAsync();

            
            if (min != -1)
                produtos = produtos.Where(y => y.PrecoDescontado >= min);
            if (max != 0)
                produtos = produtos.Where(y => y.PrecoDescontado <= max);
            if (marca != -1)
                produtos = produtos.Where(y => y.MarcaProdutoId == marca);
            if (idade != "")
                produtos = produtos.Where(y => y.Descricao!.Contains(idade));
            if (porte != "")
                produtos = produtos.Where(y => y.Descricao!.Contains(porte));
            if (linha != "")
                produtos = produtos.Where(y => y.Descricao!.Contains(linha));
            if (tipo != -1)
                produtos = produtos.Where(y => y.TipoProdutoId == tipo);
            if (ordem != -1) 
            {
                switch (ordem)
                {
                    //Maior Preco
                    case 1:
                        produtos = produtos.OrderByDescending(y => y.Preco);
                        break;

                    case 2:
                        produtos = produtos.OrderBy(y => y.Preco);
                        break;

                    //A - Z
                    case 3:
                        produtos = produtos.OrderBy(y => y.NomeProduto);
                        break;

                    //Z - A
                    case 4:
                        produtos = produtos.OrderByDescending(y => y.NomeProduto);
                        break;

                    //Maior Desconto
                    case 5:
                        produtos = produtos.OrderByDescending(y => y.Desconto);
                        break;
                }
            }

            var total = produtos.Count(); 

            if (produtos.Count() == 0 ) 
                return NotFound();
            else
                return Ok
                (
                    new 
                    {
                        total,
                        produtos,
                    }
                );
        }
        catch 
        {
            return BadRequest( new { Message = "Não foi possível fazer a consulta"});
        }
        
        
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Produto>> GetPorId(
            [FromRoute] int id,
            [FromServices] DataContext context)
    {
        try
        {

            var produto = await context
                                    .Produto
                                    .Include(x => x.ImageProduto!.Take(3))
                                    .AsNoTracking()
                                    .Where(x => x.Id == id)
                                    .FirstOrDefaultAsync();
            if (produto == null ) 
                return NotFound();
            else
                return Ok(produto);
        }
        catch 
        {
            return BadRequest( new { Message = "Não foi possível fazer a consulta"});
        }
        
        
    }



    [HttpGet]
    [Route("relacionados/{tipo:int}/{pet:int}")]
    public async Task<ActionResult<List<Produto>>> GetRelacionados(
            [FromRoute] int tipo,
            [FromRoute] int pet,
            [FromServices] DataContext context)
    {
        try
        {

            var produto = await context
                                    .Produto
                                    .Include(x => x.ImageProduto!.Take(1))
                                    .AsNoTracking()
                                    .Where(x => (x.TipoProdutoId == tipo && x.PetId == pet))
                                    .ToListAsync();
            if (produto.Count() == 0 ) 
                return NotFound();
            else
                return Ok(produto);
        }
        catch 
        {
            return BadRequest( new { Message = "Não foi possível fazer a consulta"});
        }
        
        
    }


    [HttpGet]
    [Route("busca/{busca}")]
    public async Task<ActionResult<List<Produto>>> GetPorBusca(
            [FromServices] DataContext context,
            [FromRoute] string busca,
            [FromQuery] int tipo = -1,
            [FromQuery] string linha = "",
            [FromQuery] int pet = -1,
            [FromQuery] string porte = "",
            [FromQuery] string idade = "",
            [FromQuery] int ordem = -1,
            [FromQuery] int marca = -1,
            [FromQuery] double max = 0,
            [FromQuery] double min = -1,
            [FromQuery] int pagina = 1)
    {
        try
        {
            IEnumerable<Produto> produtos = await context
                                    .Produto
                                    .Include(x => x.ImageProduto!.Take(1))
                                    .AsNoTracking()
                                    .Where(x => (x.Descricao!.Contains(busca) || x.NomeProduto!.Contains(busca)))
                                    .Skip((pagina -1) * 12)
                                    .Take(12)
                                    .ToListAsync();
            if (min != -1)
                produtos = produtos.Where(y => y.PrecoDescontado >= min);
            if (max != 0)
                produtos = produtos.Where(y => y.PrecoDescontado <= max);
            if (marca != -1)
                produtos = produtos.Where(y => y.MarcaProdutoId == marca);
            if (idade != "")
                produtos = produtos.Where(y => y.Descricao!.Contains(idade));
            if (porte != "")
                produtos = produtos.Where(y => y.Descricao!.Contains(porte));
            if (pet != -1)
                produtos = produtos.Where(y => y.PetId == pet);
            if (linha != "")
                produtos = produtos.Where(y => y.Descricao!.Contains(linha));
            if (tipo != -1)
                produtos = produtos.Where(y => y.TipoProdutoId == tipo);
            if (ordem != -1) 
            {
                switch (ordem)
                {
                    //Maior Preco
                    case 1:
                        produtos = produtos.OrderByDescending(y => y.Preco);
                        break;

                    case 2:
                        produtos = produtos.OrderBy(y => y.Preco);
                        break;

                    //A - Z
                    case 3:
                        produtos = produtos.OrderBy(y => y.NomeProduto);
                        break;

                    //Z - A
                    case 4:
                        produtos = produtos.OrderByDescending(y => y.NomeProduto);
                        break;

                    //Maior Desconto
                    case 5:
                        produtos = produtos.OrderByDescending(y => y.Desconto);
                        break;
                }
            }

            var total = produtos.Count();                 

            if (produtos.Count() == 0 ) 
                return NotFound();
            else
                return Ok
                (
                    new 
                    {
                        total,
                        produtos
                    }
                );
        }
        catch 
        {
            return BadRequest( new { Message = "Não foi possível fazer a consulta"});
        }
        
        
    }


    [HttpGet]
    [Route("ofertas")]
    public async Task<ActionResult<List<Produto>>> GetOfertas([FromServices] DataContext context)
    {
        try
        {

            var produto = await context
                                    .Produto
                                    .Include(x => x.ImageProduto!.Take(1))
                                    .AsNoTracking()
                                    .Take(5)
                                    .OrderByDescending(x => x.Desconto)
                                    .ToListAsync();
            if (produto.Count() == 0 ) 
                return NotFound();
            else
                return Ok(produto);
        }
        catch 
        {
            return BadRequest( new { Message = "Não foi possível fazer a consulta"});
        }
        
        
    }

    [HttpPost]
    [Route("avaliacao")]
    public async Task<ActionResult<AvaliacaoProduto>> Avaliar([FromServices] DataContext context,
                                                              [FromBody] AvaliacaoProduto avaliacao)
    {
        try
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            int claimid = 0;
            if (identity != null)
                claimid = Int32.Parse(identity.FindFirst("ClienteId")!.Value);
            else
                return NotFound( new { Message = "Usuário não está logado" } );

            var avaliacaodb = await context
                                            .AvaliacaoProduto
                                            .AsNoTracking()
                                            .Where(x => x.ClienteId == claimid && x.ProdutoId == avaliacao.ClienteId)
                                            .FirstOrDefaultAsync();
            if (avaliacaodb != null)
                return BadRequest( new { Message = "Avaliação já feita" } );

            avaliacao.ClienteId = claimid;
            context.AvaliacaoProduto.Add(avaliacao);
            await context.SaveChangesAsync();
            return Ok();
        }
        catch 
        {
            return BadRequest( new { Message = "Não foi possível fazer a avalição do produto" } );
        }
    }
}