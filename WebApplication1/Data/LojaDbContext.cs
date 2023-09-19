using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Data;
public class LojaDbContext : DbContext
{
    public DbSet<Cliente>? Cliente { get; set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("DataSource=loja.db;Cache=Shared");
    }

}