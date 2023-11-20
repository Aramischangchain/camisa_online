using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;

public class Estoque
{
    [Key] [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int EstoqueId { get; set;}
    public int? Quantidade {get; set;}
}