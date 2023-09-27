using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication1.Models;

namespace WebApplication1.Controllers;
public class Carrinho
{
   [Key]
   [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CarrinhoId { get; set; }
    public string? Status { get; set; }
    public float? Preco { get; set; }
}