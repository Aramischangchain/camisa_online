using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;

public class Fornecedor
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int FornecedorId { get; set; }

    public int? Nome { get; set; }

    public string? Contato {get; set; }

    public double? Endereco {get; set; }
    public List<Produto> Produto { get; set; } = new List<Produto>(); // Relação 0 para muitos com Produto


}