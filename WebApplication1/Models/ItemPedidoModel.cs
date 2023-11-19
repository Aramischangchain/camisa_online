using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;

public class ItemPedido
{
    [Key] [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ItemPedidoId {get; set;}
    public string? Descricao {get; set;}
    public string? Quantidade {get; set;}
    public int? ProdutoId {get; set;}
    public Produto? Produto{get; set;}

}