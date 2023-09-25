﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication1.Data;

#nullable disable

namespace WebApplication1.Migrations
{
    [DbContext(typeof(LojaDbContext))]
    [Migration("20230925182608_AlteraçcaoPrincipa6")]
    partial class AlteraçcaoPrincipa6
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefone")
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

                    b.Property<int>("PedidoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Validade")
                        .HasColumnType("TEXT");

                    b.HasKey("PagamentoId");

                    b.HasIndex("PedidoId")
                        .IsUnique();

                    b.ToTable("Pagamento");
                });

            modelBuilder.Entity("WebApplication1.Models.Estoque", b =>
                {
                    b.Property<int>("EstoqueId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descricao")
                        .HasColumnType("TEXT");

                    b.Property<string>("Quantidade")
                        .HasColumnType("TEXT");

                    b.HasKey("EstoqueId");

                    b.ToTable("Estoque");
                });

            modelBuilder.Entity("WebApplication1.Models.Fornecedor", b =>
                {
                    b.Property<int>("FornecedorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Contato")
                        .HasColumnType("TEXT");

                    b.Property<double?>("Endereco")
                        .HasColumnType("REAL");

                    b.Property<int?>("Nome")
                        .HasColumnType("INTEGER");

                    b.HasKey("FornecedorId");

                    b.ToTable("Fornecedor");
                });

            modelBuilder.Entity("WebApplication1.Models.Funcionario", b =>
                {
                    b.Property<int>("FuncionarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cargo")
                        .HasColumnType("TEXT");

                    b.Property<int>("LojaId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<double?>("Salario")
                        .HasColumnType("REAL");

                    b.HasKey("FuncionarioId");

                    b.HasIndex("LojaId");

                    b.ToTable("Funcionario");
                });

            modelBuilder.Entity("WebApplication1.Models.ItemPedido", b =>
                {
                    b.Property<int>("ItemPedidoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descricao")
                        .HasColumnType("TEXT");

                    b.Property<int>("PedidoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Quantidade")
                        .HasColumnType("TEXT");

                    b.HasKey("ItemPedidoId");

                    b.HasIndex("PedidoId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("ItemPedido");
                });

            modelBuilder.Entity("WebApplication1.Models.Loja", b =>
                {
                    b.Property<int>("LojaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Endereco")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.HasKey("LojaId");

                    b.ToTable("Loja");
                });

            modelBuilder.Entity("WebApplication1.Models.Pedido", b =>
                {
                    b.Property<int>("PedidoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClienteId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("DataPedido")
                        .HasColumnType("TEXT");

                    b.Property<int?>("Numero")
                        .HasColumnType("INTEGER");

                    b.Property<double?>("Status")
                        .HasColumnType("REAL");

                    b.HasKey("PedidoId");

                    b.HasIndex("ClienteId");

                    b.ToTable("Pedido");
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

                    b.Property<int>("EstoqueId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FornecedorId")
                        .HasColumnType("INTEGER");

                    b.Property<double?>("Preco")
                        .HasColumnType("REAL");

                    b.Property<string>("Tamanho")
                        .HasColumnType("TEXT");

                    b.HasKey("ProdutoId");

                    b.HasIndex("EstoqueId");

                    b.HasIndex("FornecedorId");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("WebApplication1.Controllers.Pagamento", b =>
                {
                    b.HasOne("WebApplication1.Models.Pedido", "Pedido")
                        .WithOne("Pagamento")
                        .HasForeignKey("WebApplication1.Controllers.Pagamento", "PedidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pedido");
                });

            modelBuilder.Entity("WebApplication1.Models.Funcionario", b =>
                {
                    b.HasOne("WebApplication1.Models.Loja", "Loja")
                        .WithMany("Funcionario")
                        .HasForeignKey("LojaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Loja");
                });

            modelBuilder.Entity("WebApplication1.Models.ItemPedido", b =>
                {
                    b.HasOne("WebApplication1.Models.Pedido", "Pedido")
                        .WithMany("ItensPedido")
                        .HasForeignKey("PedidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Models.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pedido");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("WebApplication1.Models.Pedido", b =>
                {
                    b.HasOne("WebApplication1.Controllers.Cliente", "Cliente")
                        .WithMany("Pedido")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("WebApplication1.Models.Produto", b =>
                {
                    b.HasOne("WebApplication1.Models.Estoque", "Estoque")
                        .WithMany("Produto")
                        .HasForeignKey("EstoqueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Models.Fornecedor", "Fornecedor")
                        .WithMany("Produto")
                        .HasForeignKey("FornecedorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estoque");

                    b.Navigation("Fornecedor");
                });

            modelBuilder.Entity("WebApplication1.Controllers.Cliente", b =>
                {
                    b.Navigation("Pedido");
                });

            modelBuilder.Entity("WebApplication1.Models.Estoque", b =>
                {
                    b.Navigation("Produto");
                });

            modelBuilder.Entity("WebApplication1.Models.Fornecedor", b =>
                {
                    b.Navigation("Produto");
                });

            modelBuilder.Entity("WebApplication1.Models.Loja", b =>
                {
                    b.Navigation("Funcionario");
                });

            modelBuilder.Entity("WebApplication1.Models.Pedido", b =>
                {
                    b.Navigation("ItensPedido");

                    b.Navigation("Pagamento")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
