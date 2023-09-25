using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;

public class Produto
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ProdutoId { get; set; }
    public string? Descricao { get; set; }
    public string? Cor {get; set; }
    public double? Preco {get; set; }
    public string? Tamanho {get; set; }
    public int EstoqueId { get; set; } // Chave estrangeira para Estoque
    public Estoque Estoque { get; set; } // Propriedade de navegação para Estoque
    public int FornecedorId { get; set; } // Chave estrangeira para Fornecedor
    public Fornecedor Fornecedor { get; set; } // Propriedade de navegação para Fornecedor
    
}