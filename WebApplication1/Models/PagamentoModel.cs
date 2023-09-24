using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Controllers;
public class Pagamento
{
    [Key]
    public string? NumeroCartao { get; set; }
    public string? Validade { get; set; }
    public string? NomeTitular { get; set; }
}