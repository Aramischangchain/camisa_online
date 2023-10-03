using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;

public class ItemCarrinho
{
    [Key] [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ItemCarrinhoId {get; set;}
    public string? Descricao {get; set;}
    public string? Quantidade {get; set;}

}