using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication1.Models;

namespace WebApplication1.Controllers;
public class Cliente
{
   [Key] [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ClienteId { get; set;}
    public string? Nome { get; set;}
    public string? Email { get; set;}
    public string? Endereco { get; set;}
}