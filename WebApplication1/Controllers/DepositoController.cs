using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Data;
using Microsoft.EntityFrameworkCore;
namespace WebApplication1.Controllers;

[ApiController]
[Route("[controller]")]
public class DepositoController : ControllerBase

{
    private LojaDbContext? _context;

    public DepositoController(LojaDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Deposito>>> Listar()
    {
        if(_context.Deposito is null)
            return NotFound();
        return await _context.Deposito.ToListAsync();
    }
    
    [HttpGet()]
    [Route("buscar/{DepositoId}")]
    public async Task<ActionResult<Deposito>> Buscar([FromRoute] int DepositoId)
    {
        if(_context.Deposito is null)
            return NotFound();
        var deposito = await _context.Deposito.FindAsync(DepositoId);
        if (deposito is null)
            return NotFound();
        return deposito;
    }

    [HttpPost]
    [Route("cadastrar")]
    public IActionResult Cadastrar(Deposito deposito)
    {
        _context.Add(deposito);
        _context.SaveChanges();
        return Created("", deposito);
    }
    
    
   
[HttpPut("{id}")]
public async Task<IActionResult> PutDeposito(int id, Deposito depositoAtualizado)
{
    try
    {
        // Verifique se o estoque com o ID especificado existe no banco de dados
        var existingDeposito = await _context.Deposito.FindAsync(id);

        if (existingDeposito == null)
        {
            return NotFound($"Estoque com o ID {id} não encontrado.");
        }

        // Atualize as propriedades do estoque existente com os valores do novo estoque
        existingDeposito.Quantidade= depositoAtualizado.Quantidade;
        existingDeposito.Descricao = depositoAtualizado.Descricao;

        await _context.SaveChangesAsync();

        return NoContent(); // Indica que a atualização foi bem-sucedida, sem conteúdo de resposta.
    }
    catch (Exception ex)
    {
        return StatusCode(500, $"Ocorreu um erro durante a atualização do estoque: {ex.Message}");
    }
}

    [HttpDelete()]
    [Route("excluir/{DepositoId}")]
    public async Task<ActionResult> Excluir(int DepositoId)
    {
        if(_context is null) return NotFound();
        if(_context.Deposito is null) return NotFound();
        var depositoTemp = await _context.Deposito.FindAsync(DepositoId);
        if(depositoTemp is null) return NotFound();
        _context.Remove(depositoTemp);
        await _context.SaveChangesAsync();
        return Ok();
    }

}





