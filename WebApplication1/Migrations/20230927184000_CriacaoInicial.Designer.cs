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
    [Migration("20230927184000_CriacaoInicial")]
    partial class CriacaoInicial
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

                    b.Property<string>("Validade")
                        .HasColumnType("TEXT");

                    b.HasKey("PagamentoId");

                    b.ToTable("Pagamento");
                });

            modelBuilder.Entity("WebApplication1.Models.Carrinho", b =>
                {
                    b.Property<int?>("CarrinhoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<float?>("Preco")
                        .HasColumnType("REAL");

                    b.Property<string>("Status")
                        .HasColumnType("TEXT");

                    b.HasKey("CarrinhoId");

                    b.ToTable("Carrinho");
                });

            modelBuilder.Entity("WebApplication1.Models.Estoque", b =>
                {
                    b.Property<int>("EstoqueId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

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

            modelBuilder.Entity("WebApplication1.Models.ItemCarrinho", b =>
                {
                    b.Property<int>("ItemCarrinhoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descricao")
                        .HasColumnType("TEXT");

                    b.Property<string>("Quantidade")
                        .HasColumnType("TEXT");

                    b.HasKey("ItemCarrinhoId");

                    b.ToTable("ItemCarrinho");
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
#pragma warning restore 612, 618
        }
    }
}