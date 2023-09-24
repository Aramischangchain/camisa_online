using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;

public class Fornecedor
{
    [Key]
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int FornecedorId { get; set; }

    public int? Nome { get; set; }

    public string? Contato {get; set; }

    public double? Endereco {get; set; }

    public List<Produto> Produtos { get; set; } // Associação 1 para muitos com Produto


}