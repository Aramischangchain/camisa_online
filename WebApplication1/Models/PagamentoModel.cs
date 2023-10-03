using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Controllers;
public class Pagamento
{
    [Key] [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PagamentoId { get; set;}
    public string? NumeroCartao { get; set;}
    public string? Validade { get; set;}
    public string? NomeTitular { get; set;}
}