using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public class Produto
{
    [Key]
    public int? Id {get; set; }
    public string? descricao { get; set; }

    public string? cor {get; set; }

    public double? preco {get; set; }

    public string? tamanho {get; set; }



}