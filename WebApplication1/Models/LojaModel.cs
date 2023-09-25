using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;

public class Loja
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int LojaId { get; set; }
    public string? Nome { get; set; }
    public string? Endereco {get; set; }
    public List<Funcionario> Funcionario { get; set; } = new List<Funcionario>(); // Relação 0 para muitos com Funcionario

}