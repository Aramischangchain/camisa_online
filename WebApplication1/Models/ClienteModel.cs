using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Controllers;
public class Cliente
{
    [Key]
    public string? Nome { get; set; }
    public string? Email { get; set; }
    public string? Telefone { get; set; }
}