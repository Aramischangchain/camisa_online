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
    [Migration("20230924165546_AdicionadoUpdateCliente")]
    partial class AdicionadoUpdateCliente
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.11");

            modelBuilder.Entity("WebApplication1.Controllers.Cliente", b =>
                {
                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefone")
                        .HasColumnType("TEXT");

                    b.HasKey("Nome");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("WebApplication1.Models.Produto", b =>
                {
                    b.Property<string>("Descricao")
                        .HasColumnType("TEXT");

                    b.Property<string>("Cor")
                        .HasColumnType("TEXT");

                    b.Property<double?>("Preco")
                        .HasColumnType("REAL");

                    b.Property<string>("Tamanho")
                        .HasColumnType("TEXT");

                    b.HasKey("Descricao");

                    b.ToTable("Produto");
                });
#pragma warning restore 612, 618
        }
    }
}
