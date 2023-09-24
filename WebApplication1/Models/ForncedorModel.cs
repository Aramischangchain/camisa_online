using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public class Fornecedor
{
    [Key]
    public int? Nome { get; set; }

    public string? Contato {get; set; }

    public double? Endereco {get; set; }

}