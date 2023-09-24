using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;

public class Estoque
{
    [Key]
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int EstoqueId { get; set; }
    public string? Descricao { get; set; }
    public string? Quantidade {get; set; }
    public List<Produto> Produtos { get; set; } // Associação 1 para muitos com Produto

}