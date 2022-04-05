﻿// <auto-generated />
using System;
using Kibexinhos.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Kibexinhos.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Kibexinhos.Models.AvaliacaoProduto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Avaliacao")
                        .HasColumnType("int");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("AvaliacaoProduto");
                });

            modelBuilder.Entity("Kibexinhos.Models.Carrinho", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("int");

                    b.Property<float>("Quantidade")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("Carrinho");
                });

            modelBuilder.Entity("Kibexinhos.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Apelido")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("CPFCNPJ")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)")
                        .HasColumnName("CPF/CNPJ");

                    b.Property<string>("Celular1")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("Celular2")
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("Newsletter")
                        .HasColumnType("bit");

                    b.Property<string>("NomeCliente")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NomeFantasia")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("RGIE")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)")
                        .HasColumnName("RG/IE");

                    b.Property<string>("RazaoSocial")
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("Kibexinhos.Models.Cupom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("datetime2");

                    b.Property<string>("Cupoom")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("Cupom");

                    b.Property<int>("PorcDesconto")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Cupom");
                });

            modelBuilder.Entity("Kibexinhos.Models.ImagemProduto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Imagem")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProdutoId");

                    b.ToTable("ImagemProduto");
                });

            modelBuilder.Entity("Kibexinhos.Models.MarcaProduto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("MarcaProduto");
                });

            modelBuilder.Entity("Kibexinhos.Models.Pedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)");

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("datetime2");

                    b.Property<int>("CupomId")
                        .HasColumnType("int");

                    b.Property<int>("Desconto")
                        .HasColumnType("int");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<double>("Frete")
                        .HasColumnType("float");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoPagamentoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("CupomId");

                    b.HasIndex("TipoPagamentoId");

                    b.ToTable("Pedido");
                });

            modelBuilder.Entity("Kibexinhos.Models.PedidoItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("PedidoId")
                        .HasColumnType("int");

                    b.Property<double>("PrecoUnit")
                        .HasColumnType("float");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("int");

                    b.Property<double>("Quantidade")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("PedidoId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("PedidoItem");
                });

            modelBuilder.Entity("Kibexinhos.Models.Pet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("TipoAnimal")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Pet");
                });

            modelBuilder.Entity("Kibexinhos.Models.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("Altura")
                        .HasColumnType("float");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<double>("Comprimento")
                        .HasColumnType("float");

                    b.Property<int>("Desconto")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double>("Estoque")
                        .HasColumnType("float");

                    b.Property<string>("InformacaoNutricional")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<double>("Largura")
                        .HasColumnType("float");

                    b.Property<int>("MarcaProdutoId")
                        .HasColumnType("int");

                    b.Property<string>("NomeProduto")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double>("Peso")
                        .HasColumnType("float");

                    b.Property<int>("PetId")
                        .HasColumnType("int");

                    b.Property<double>("Preco")
                        .HasColumnType("float");

                    b.Property<int>("TipoProdutoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MarcaProdutoId");

                    b.HasIndex("PetId");

                    b.HasIndex("TipoProdutoId");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("Kibexinhos.Models.TipoPagamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("TipoPagamento");
                });

            modelBuilder.Entity("Kibexinhos.Models.TipoProduto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("TipoProduto");
                });

            modelBuilder.Entity("Kibexinhos.Models.AvaliacaoProduto", b =>
                {
                    b.HasOne("Kibexinhos.Models.Cliente", "Cliente")
                        .WithMany("AvaliacaoProduto")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kibexinhos.Models.Produto", "Produto")
                        .WithMany("AvaliacaoProduto")
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("Kibexinhos.Models.Carrinho", b =>
                {
                    b.HasOne("Kibexinhos.Models.Cliente", "Cliente")
                        .WithMany("Carrinho")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kibexinhos.Models.Produto", "Produto")
                        .WithMany("Carrinho")
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("Kibexinhos.Models.ImagemProduto", b =>
                {
                    b.HasOne("Kibexinhos.Models.Produto", "Produto")
                        .WithMany("ImageProduto")
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("Kibexinhos.Models.Pedido", b =>
                {
                    b.HasOne("Kibexinhos.Models.Cliente", "Cliente")
                        .WithMany("Pedido")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kibexinhos.Models.Cupom", "Cupom")
                        .WithMany("Pedido")
                        .HasForeignKey("CupomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kibexinhos.Models.TipoPagamento", "Pagamento")
                        .WithMany("Pedido")
                        .HasForeignKey("TipoPagamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Cupom");

                    b.Navigation("Pagamento");
                });

            modelBuilder.Entity("Kibexinhos.Models.PedidoItem", b =>
                {
                    b.HasOne("Kibexinhos.Models.Pedido", "Pedido")
                        .WithMany("PedidoItem")
                        .HasForeignKey("PedidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kibexinhos.Models.Produto", "Produto")
                        .WithMany("PedidoItem")
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pedido");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("Kibexinhos.Models.Produto", b =>
                {
                    b.HasOne("Kibexinhos.Models.MarcaProduto", "MarcaProduto")
                        .WithMany("Product")
                        .HasForeignKey("MarcaProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kibexinhos.Models.Pet", "Pet")
                        .WithMany("Produto")
                        .HasForeignKey("PetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kibexinhos.Models.TipoProduto", "TipoProduto")
                        .WithMany("Produto")
                        .HasForeignKey("TipoProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MarcaProduto");

                    b.Navigation("Pet");

                    b.Navigation("TipoProduto");
                });

            modelBuilder.Entity("Kibexinhos.Models.Cliente", b =>
                {
                    b.Navigation("AvaliacaoProduto");

                    b.Navigation("Carrinho");

                    b.Navigation("Pedido");
                });

            modelBuilder.Entity("Kibexinhos.Models.Cupom", b =>
                {
                    b.Navigation("Pedido");
                });

            modelBuilder.Entity("Kibexinhos.Models.MarcaProduto", b =>
                {
                    b.Navigation("Product");
                });

            modelBuilder.Entity("Kibexinhos.Models.Pedido", b =>
                {
                    b.Navigation("PedidoItem");
                });

            modelBuilder.Entity("Kibexinhos.Models.Pet", b =>
                {
                    b.Navigation("Produto");
                });

            modelBuilder.Entity("Kibexinhos.Models.Produto", b =>
                {
                    b.Navigation("AvaliacaoProduto");

                    b.Navigation("Carrinho");

                    b.Navigation("ImageProduto");

                    b.Navigation("PedidoItem");
                });

            modelBuilder.Entity("Kibexinhos.Models.TipoPagamento", b =>
                {
                    b.Navigation("Pedido");
                });

            modelBuilder.Entity("Kibexinhos.Models.TipoProduto", b =>
                {
                    b.Navigation("Produto");
                });
#pragma warning restore 612, 618
        }
    }
}
