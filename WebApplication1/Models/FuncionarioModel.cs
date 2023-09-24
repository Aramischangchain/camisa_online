using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public class Funcionario
{
    [Key]
    public int? Nome { get; set; }

    public string? Cargo {get; set; }

    public double? Salario {get; set; }

}