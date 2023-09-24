using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public class Produto
{
    [Key]
    public string? Descricao { get; set; }

    public string? Cor {get; set; }

    public double? Preco {get; set; }
    public string? Tamanho {get; set; }

}