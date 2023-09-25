using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication1.Models;

namespace WebApplication1.Models;

public class Estoque
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int EstoqueId { get; set; }
    public string? Descricao { get; set; }
    public string? Quantidade {get; set; }
    public List<Produto> Produto { get; set; } = new List<Produto>(); // Relação 0 para muitos com Produto

}