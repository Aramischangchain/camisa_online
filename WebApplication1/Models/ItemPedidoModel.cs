using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public class ItemPedido
{
    [Key]
    public string? Descricao { get; set; }
    public string? Quantidade {get; set; }

}