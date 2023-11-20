using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication1.Models;

namespace WebApplication1.Controllers;
public class Pedido
{
   [Key]
   [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PedidoId { get; set; }
    public string? Status { get; set; }
    public float? Preco { get; set; }
    public int? ItemPedidoId {get; set;}
    public ItemPedido? ItemPedido{get; set;}
}