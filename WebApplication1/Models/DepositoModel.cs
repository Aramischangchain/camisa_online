using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;

public class Deposito
{
    [Key] [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int? DepositoId { get; set;}
    public string? Descricao{ get; set;}
    public int? Quantidade {get; set;}
}