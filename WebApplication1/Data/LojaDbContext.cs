using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Controllers;
namespace WebApplication1.Data;
public class LojaDbContext : DbContext
{
    public DbSet<Cliente>? Cliente { get; set;}
    public DbSet<Produto>? Produto { get; set;}
    public DbSet<Estoque>? Estoque { get; set;}
    public DbSet<ItemPedido>? ItemPedido { get; set;}
    public DbSet<Fornecedor>? Fornecedor { get; set;}
    public DbSet<Pedido>? Pedido {get; set;}
    public DbSet<Pagamento>? Pagamento {get; set;}



    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("DataSource=loja.db;Cache=Shared");
    }

}