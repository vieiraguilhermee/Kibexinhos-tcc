using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
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
            [FromQuery] int[] tipo,
            [FromQuery] int[] marca,
            [FromQuery] string[] porte,
            [FromQuery] string[] idade,
            [FromQuery] int ordem = -1,
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
            if (marca.Length != 0)
                // produtos = produtos.Where(y => y.MarcaProdutoId == marca);
                produtos = produtos.Where(y => marca.Contains(y.MarcaProdutoId));
            if (idade.Length != 0)
                // produtos = produtos.Where(y => y.Descricao!.Contains(idade));
                produtos = produtos.Where(y => idade.Any(y.Descricao!.Contains));
            if (porte.Length != 0)
                // produtos = produtos.Where(y => y.Descricao!.Contains(porte));
                produtos = produtos.Where(y => porte.Any(y.Descricao!.Contains));
            if (tipo.Length != 0)
                // produtos = produtos.Where(y => y.TipoProdutoId == tipo);
                produtos = produtos.Where(y => tipo.Contains(y.TipoProdutoId));
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
                                    .Include(x => x.MarcaProduto)
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
            [FromQuery] int[] tipo,
            [FromQuery] int[] pet,
            [FromQuery] string[] porte,
            [FromQuery] string[] idade,
            [FromQuery] int[] marca,
            [FromQuery] int ordem = -1,
            [FromQuery] double max = 0,
            [FromQuery] double min = -1,
            [FromQuery] int pagina = 1)
    {
        string [] palavraschave = busca.Split(" ");
        try
        {
            IEnumerable<Produto> produtos = await context
                                    .Produto
                                    .Include(x => x.ImageProduto!.Take(1))
                                    .AsNoTracking()
                                    .Where(x => (palavraschave.Any(x.Descricao!.Contains) || 
                                                 palavraschave.Any(x.NomeProduto!.Contains)))
                                    .Skip((pagina -1) * 12)
                                    .Take(12)
                                    .ToListAsync();
            if (min != -1)
                produtos = produtos.Where(y => y.PrecoDescontado >= min);
            if (max != 0)
                produtos = produtos.Where(y => y.PrecoDescontado <= max);
            if (marca.Length != 0)
                // produtos = produtos.Where(y => y.MarcaProdutoId == marca);
                produtos = produtos.Where(y => marca.Contains(y.MarcaProdutoId));
            if (idade.Length != 0)
                // produtos = produtos.Where(y => y.Descricao!.Contains(idade));
                produtos = produtos.Where(y => idade.Any(y.Descricao!.Contains));
            if (porte.Length != 0)
                // produtos = produtos.Where(y => y.Descricao!.Contains(porte));
                produtos = produtos.Where(y => porte.Any(y.Descricao!.Contains));
            if (tipo.Length != 0)
                // produtos = produtos.Where(y => y.TipoProdutoId == tipo);
                produtos = produtos.Where(y => tipo.Contains(y.TipoProdutoId));
            if (pet.Length != 0)
                // produtos = produtos.Where(y => y.TipoProdutoId == tipo);
                produtos = produtos.Where(y => pet.Contains(y.PetId));
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

    // [HttpGet]
    // [Route("maisvendidosgatos")]
    // public async Task<ActionResult<List<Produto>>> GetMaisVendidosGatos([FromServices] DataContext context)
    // {
    //     try
    //     {

    //         var produto = await  (from item in context.PedidoItem
    //                             group item.Quantidade by item.Produto into g
    //                             orderby g.Sum() descending
    //                             select g).Take(5).ToListAsync();

    //         if (produto.Count() == 0 ) 
    //             return NotFound();
    //         else
    //             return Ok(produto);
    //     }
    //     catch 
    //     {
    //         return BadRequest( new { Message = "Não foi possível fazer a consulta"});
    //     }
          
    // }

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

    [HttpGet]
    [Route("maisvendidos/{pet:int}")]
    public async Task<ActionResult> MaisVendidos([FromServices] DataContext context, [FromRoute] int pet)
    {
        try
        {
            var ids = await context
                                .PedidoItem
                                .Where(x => x.Produto!.PetId == 1)
                                .GroupBy(x => x.ProdutoId)
                                .Select(x => new 
                                {
                                    ProdutoId = x.Key,
                                    Quantidade = x.Sum(y => y.Quantidade)
                                })
                                .OrderByDescending(x => x.Quantidade)
                                .Select(x => x.ProdutoId)
                                .ToArrayAsync();

            var produtos = await context
                                        .Produto
                                        .Include(x => x.ImageProduto!.Take(1))
                                        .AsNoTracking()
                                        .Where(y => ids.Contains(y.Id))
                                        .Take(5)
                                        .ToListAsync();

            return Ok(produtos);
        }
        catch 
        {
            return BadRequest( new { Message = "Não foi possível fazer a consulta" } );
        }   
    }
}