﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication1.Data;

#nullable disable

namespace WebApplication1.Migrations
{
    [DbContext(typeof(LojaDbContext))]
    partial class LojaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.11");

            modelBuilder.Entity("WebApplication1.Controllers.Cliente", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Endereco")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.HasKey("ClienteId");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("WebApplication1.Controllers.Pagamento", b =>
                {
                    b.Property<int>("PagamentoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("NomeTitular")
                        .HasColumnType("TEXT");

                    b.Property<string>("NumeroCartao")
                        .HasColumnType("TEXT");

                    b.Property<int?>("PedidoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Validade")
                        .HasColumnType("TEXT");

                    b.HasKey("PagamentoId");

                    b.HasIndex("PedidoId");

                    b.ToTable("Pagamento");
                });

            modelBuilder.Entity("WebApplication1.Controllers.Pedido", b =>
                {
                    b.Property<int>("PedidoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ItemPedidoId")
                        .HasColumnType("INTEGER");

                    b.Property<float?>("Preco")
                        .HasColumnType("REAL");

                    b.Property<string>("Status")
                        .HasColumnType("TEXT");

                    b.HasKey("PedidoId");

                    b.HasIndex("ItemPedidoId");

                    b.ToTable("Pedido");
                });

            modelBuilder.Entity("WebApplication1.Models.Deposito", b =>
                {
                    b.Property<int?>("DepositoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descricao")
                        .HasColumnType("TEXT");

                    b.Property<int?>("Quantidade")
                        .HasColumnType("INTEGER");

                    b.HasKey("DepositoId");

                    b.ToTable("Deposito");
                });

            modelBuilder.Entity("WebApplication1.Models.Fornecedor", b =>
                {
                    b.Property<int>("FornecedorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Contato")
                        .HasColumnType("TEXT");

                    b.Property<string>("Endereco")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.HasKey("FornecedorId");

                    b.ToTable("Fornecedor");
                });

            modelBuilder.Entity("WebApplication1.Models.ItemPedido", b =>
                {
                    b.Property<int>("ItemPedidoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descricao")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ProdutoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Quantidade")
                        .HasColumnType("TEXT");

                    b.HasKey("ItemPedidoId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("ItemPedido");
                });

            modelBuilder.Entity("WebApplication1.Models.Produto", b =>
                {
                    b.Property<int>("ProdutoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cor")
                        .HasColumnType("TEXT");

                    b.Property<string>("Descricao")
                        .HasColumnType("TEXT");

                    b.Property<double?>("Preco")
                        .HasColumnType("REAL");

                    b.Property<string>("Tamanho")
                        .HasColumnType("TEXT");

                    b.HasKey("ProdutoId");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("WebApplication1.Controllers.Pagamento", b =>
                {
                    b.HasOne("WebApplication1.Controllers.Pedido", "Pedido")
                        .WithMany()
                        .HasForeignKey("PedidoId");

                    b.Navigation("Pedido");
                });

            modelBuilder.Entity("WebApplication1.Controllers.Pedido", b =>
                {
                    b.HasOne("WebApplication1.Models.ItemPedido", "ItemPedido")
                        .WithMany()
                        .HasForeignKey("ItemPedidoId");

                    b.Navigation("ItemPedido");
                });

            modelBuilder.Entity("WebApplication1.Models.ItemPedido", b =>
                {
                    b.HasOne("WebApplication1.Models.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId");

                    b.Navigation("Produto");
                });
#pragma warning restore 612, 618
        }
    }
}
