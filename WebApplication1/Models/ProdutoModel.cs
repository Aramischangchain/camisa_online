using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;

public class Produto
{
    [Key]
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ProdutoId { get; set; }
    public string? Descricao { get; set; }

    public string? Cor {get; set; }

    public double? Preco {get; set; }
    public string? Tamanho {get; set; }
    
}