using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Model
{
    [Table("cliente")]
    public class Cliente
    {

    [Key]
    public int id {get; private set;}
    public string name {get; private set;}
    public string email {get; private set;}
    }

}