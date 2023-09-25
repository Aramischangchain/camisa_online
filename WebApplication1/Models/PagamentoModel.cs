using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication1.Models;


namespace WebApplication1.Controllers;
public class Pagamento
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PagamentoId { get; set; }
    public string? NumeroCartao { get; set; }
    public string? Validade { get; set; }
    public string? NomeTitular { get; set; }
     public int PedidoId { get; set; } // Chave estrangeira para Pedido
    public Pedido Pedido { get; set; } // Propriedade de navegação para Pedido
}