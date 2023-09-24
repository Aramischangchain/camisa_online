using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public class Loja
{
    [Key]
    public string? Nome { get; set; }

    public string? Endereco {get; set; }


}