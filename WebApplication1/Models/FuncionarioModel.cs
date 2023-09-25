using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;

public class Funcionario
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int FuncionarioId { get; set; }

    public string? Nome { get; set; }

    public string? Cargo {get; set; }

    public double? Salario {get; set; }
    public int LojaId { get; set; } // Chave estrangeira para Loja
    public Loja Loja { get; set; } // Propriedade de navegação para Loja

}