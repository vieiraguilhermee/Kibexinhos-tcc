using Kibexinhos.Data;
using Kibexinhos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("Teste")]
public class TesteController : ControllerBase
{

    [HttpGet]
    [Route("tipo")]
    public async Task<ActionResult> Tipo([FromServices] DataContext context)
    {
        List<TipoProduto> listatipo = new List<TipoProduto>();
        for (int i = 1; i <= 10; i++)
        {
            TipoProduto produto = new TipoProduto() { Tipo = $"Tipo{i}"};
            listatipo.Add(produto);
        }
        context.TipoProduto.AddRange(listatipo);

        await context.SaveChangesAsync();

        return Ok();
        
    }

    [HttpGet]
    [Route("marca")]
    public async Task<ActionResult> Marca([FromServices] DataContext context)
    {
        List<MarcaProduto> listamarca = new List<MarcaProduto>();
        for (int i = 1; i <= 10; i++)
        {
            MarcaProduto marca = new MarcaProduto() { Marca = "Marca" + i.ToString()};
            listamarca.Add(marca);
        }
        context.MarcaProduto.AddRange(listamarca);

        await context.SaveChangesAsync();
        return Ok();
    }

    [HttpGet]
    [Route("pet")]
    public async Task<ActionResult> Pet([FromServices] DataContext context)
    {
        List<Pet> listapet = new List<Pet>();
        for (int i = 1; i <= 10; i++)
        {
            Pet pet = new Pet() { TipoAnimal = "TipoAnimal" + i.ToString()};
            listapet.Add(pet);
        }
        context.Pet.AddRange(listapet);

        await context.SaveChangesAsync();
        return Ok();
    }

    [HttpGet]
    [Route("produto")]
    public async Task<ActionResult> Produto([FromServices] DataContext context)
    {
        int j = 1;
        List<Produto> listaproduto = new List<Produto>();
        for (int i = 1; i <= 20; i++)
        {
            Produto produto = new Produto() 
            { 
                NomeProduto = "Produto" + i.ToString(),
                Descricao = "Descricao" + i.ToString(),
                Preco = 20 * i,
                Estoque = 10 * i,
                Desconto = 2 * i,
                TipoProdutoId = j,
                MarcaProdutoId = j,
                PetId = j,
                Ativo = true
            };
            if (i % 2 == 0)
            {
                j++;
            }
            listaproduto.Add(produto);
        }
        context.Produto.AddRange(listaproduto);
        await context.SaveChangesAsync();

        return Ok();
        
    }

    [HttpGet]
    [Route("produtotest")]
    public async Task<ActionResult> testin([FromServices] DataContext context)
    {

            Produto produto = new Produto() 
            { 
                NomeProduto = "Produto101",
                Descricao = "Descricao",
                Preco = 20 ,
                Estoque = 10 ,
                Desconto = 2 ,
                TipoProdutoId = 1,
                MarcaProdutoId = 1,
                PetId = 1,
                Ativo = false
            };


        context.Produto.Add(produto);
        await context.SaveChangesAsync();

        return Ok();
        
    }

    [HttpGet]
    [Route("imagem")]
    public async Task<ActionResult> Imagens([FromServices] DataContext context)
    {
        int j = 1;
        List<ImagemProduto> listaimagem = new List<ImagemProduto>();
        for (int i = 1; i <= 60; i++)
        {
            ImagemProduto imagem = new ImagemProduto() 
            { 
                ProdutoId = j,
                Imagem = "https://m.imgur.com/UkkQV7a"
            };
            if (i % 3 == 0)
            {
                j++;
            }
            listaimagem.Add(imagem);
        }
        context.ImagemProduto.AddRange(listaimagem);
        await context.SaveChangesAsync();

        return Ok();
        
    }

    [HttpGet]
    [Route("pagamento")]
    public async Task<ActionResult> Pagamento([FromServices] DataContext context)
    {
        List<TipoPagamento> listapagamento = new List<TipoPagamento>();
        for (int i = 1; i <= 10; i++)
        {
            TipoPagamento imagem = new TipoPagamento() { Tipo = "Tipo" + i.ToString()};
            listapagamento.Add(imagem);
        }
        context.TipoPagamento.AddRange(listapagamento);

        await context.SaveChangesAsync();
        return Ok();
    }

    [HttpGet]
    [Route("cupom")]
    public async Task<ActionResult> Cupom([FromServices] DataContext context)
    {
        List<Cupom> listacupom = new List<Cupom>();
        for (int i = 1; i <= 10; i++)
        {
            Cupom cupom = new Cupom() 
            { 
                Cupoom = "Cupom" + i.ToString(),
                PorcDesconto = 10 * i,
                Ativo = true
            };
            listacupom.Add(cupom);
        }
        context.Cupom.AddRange(listacupom);

        await context.SaveChangesAsync();
        return Ok();
    }

    [HttpGet]
    [Route("cliente")]
    public async Task<ActionResult> Cliente([FromServices] DataContext context)
    {
        List<Cliente> listacliente = new List<Cliente>();
        for (int i = 1; i <= 10; i++)
        {
            Cliente cliente = new Cliente() 
            { 
                NomeCliente = "Cliente" + i.ToString(),
                DataNascimento = DateTime.Today.AddYears(1 * i),
                Apelido = "Apelido" + i.ToString(),
                CPFCNPJ = (1231231230 + i).ToString(),
                RGIE = (1212312300 + i).ToString(),
                Email = "email" + i.ToString() + "@hotmail.com",
                Senha = (12345678 + 1).ToString(),
                CEP = "17220000",
                Celular1 = "14998808080",
                Ativo = true, 
                Newsletter = true
            };
            listacliente.Add(cliente);
        }
        context.Cliente.AddRange(listacliente);

        await context.SaveChangesAsync();
        return Ok();
    }

    [HttpGet]
    [Route("avaliacao")]
    public async Task<ActionResult> Pedido([FromServices] DataContext context)
    {
        List<AvaliacaoProduto> listaavaliacao = new List<AvaliacaoProduto>();
        // for (int i = 1; i <= 20; i++)
        // {
        //     AvaliacaoProduto avaliacao = new AvaliacaoProduto() 
        //     { 
        //         ProdutoId = i,
        //         ClienteId = i,
        //         Avaliacao = 5
        //     };
        //     listaavaliacao.Add(avaliacao);
        // }

        AvaliacaoProduto a1 = new AvaliacaoProduto() { ProdutoId = 1, ClienteId = 1, Avaliacao = 5};
        listaavaliacao.Add(a1);
        AvaliacaoProduto a2 = new AvaliacaoProduto() { ProdutoId = 2, ClienteId = 2, Avaliacao = 5};
        listaavaliacao.Add(a2);
        AvaliacaoProduto a3 = new AvaliacaoProduto() { ProdutoId = 3, ClienteId = 3, Avaliacao = 5};
        listaavaliacao.Add(a3);
        AvaliacaoProduto a4 = new AvaliacaoProduto() { ProdutoId = 4, ClienteId = 4, Avaliacao = 5};
        listaavaliacao.Add(a4);
        AvaliacaoProduto a5 = new AvaliacaoProduto() { ProdutoId = 5, ClienteId = 5, Avaliacao = 5};
        listaavaliacao.Add(a5);
        AvaliacaoProduto a6 = new AvaliacaoProduto() { ProdutoId = 6, ClienteId = 6, Avaliacao = 5};
        listaavaliacao.Add(a6);
        AvaliacaoProduto a7 = new AvaliacaoProduto() { ProdutoId = 7, ClienteId = 7, Avaliacao = 5};
        listaavaliacao.Add(a7);
        AvaliacaoProduto a8 = new AvaliacaoProduto() { ProdutoId = 8, ClienteId = 8, Avaliacao = 5};
        listaavaliacao.Add(a8);
        AvaliacaoProduto a9 = new AvaliacaoProduto() { ProdutoId = 9, ClienteId = 9, Avaliacao = 5};
        listaavaliacao.Add(a9);
        AvaliacaoProduto a10 = new AvaliacaoProduto() { ProdutoId = 10, ClienteId = 10, Avaliacao = 5};
        listaavaliacao.Add(a10);
        context.AvaliacaoProduto.AddRange(listaavaliacao);

        await context.SaveChangesAsync();
        return Ok();
    }

}