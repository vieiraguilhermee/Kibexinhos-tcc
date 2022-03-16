using Microsoft.EntityFrameworkCore;
using Kibexinhos.Models;

namespace Kibexinhos.Data 
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}

        public DbSet<AvaliacaoProduto> AvaliacaoProduto { get; set;} = null!;

        public DbSet<Carrinho> Carrinho { get; set;} = null!;

        public DbSet<Cliente> Cliente { get; set;}  = null!;
        
        public DbSet<Cupom> Cupom { get; set;}  = null!;

        public DbSet<ImagemProduto> ImagemProduto { get; set;}   = null!;

        public DbSet<MarcaProduto> MarcaProduto { get; set;}   = null!;

        public DbSet<Pedido> Pedido { get; set;}   = null!;

        public DbSet<PedidoItem> PedidoItem { get; set;}   = null!;

        public DbSet<Produto> Produto { get; set;}   = null!;

        public DbSet<TipoPagamento> TipoPagamento { get; set;}   = null!;

        public DbSet<TipoProduto> TipoProduto { get; set;}   = null!;

        public DbSet<Pet> Pet { get; set;}  = null!;
        
    }
}