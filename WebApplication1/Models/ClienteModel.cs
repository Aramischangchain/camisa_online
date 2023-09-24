using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Controllers;
public class Cliente
{
   [Key]
   [Required]
   [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ClienteId { get; set; }
    public string? Nome { get; set; }
    public string? Email { get; set; }
    public string? Telefone { get; set; }
    public List<Models.Pedido> Pedidos { get; set; } // Associação 1 para muitos com Pedido

}