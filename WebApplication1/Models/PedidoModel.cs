using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication1.Controllers;
namespace WebApplication1.Models;

public class Pedido
{
    [Key]
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PedidoId { get; set; }

    public int? Numero { get; set; }

    public string? DataPedido {get; set; }

    public double? Status {get; set; }
     public int ClienteId { get; set; } // Chave estrangeira para Cliente
    public Cliente Cliente { get; set; } // Propriedade de navegação para Cliente
    public List<ItemPedido> ItensPedido { get; set; } // Associação 1 para muitos com ItemPedido
    public Pagamento Pagamento { get; set; } // Associação 1 para 1 com Pagamento

}