using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;
public class Cliente
{
    [Key]
    public string? Nome { get; set; }
    public string? Email { get; set; }
}