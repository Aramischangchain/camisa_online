using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public class Pedido
{
    [Key]
    public int? Numero { get; set; }

    public string? DataPedido {get; set; }

    public double? Status {get; set; }

}