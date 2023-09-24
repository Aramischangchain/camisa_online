using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;

public class Loja
{
    [Key]
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int LojaId { get; set; }
    public string? Nome { get; set; }
    public string? Endereco {get; set; }
    public List<Funcionario> Funcionarios { get; set; } // Associação 1 para muitos com Funcionario



}