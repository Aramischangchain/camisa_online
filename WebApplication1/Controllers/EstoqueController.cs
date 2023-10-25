using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Data;
using Microsoft.EntityFrameworkCore;
namespace WebApplication1.Controllers;

[ApiController]
[Route("[controller]")]
public class EstoqueController : ControllerBase

{
    private LojaDbContext? _context;

    public EstoqueController(LojaDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Estoque>>> Listar()
    {
        if(_context.Estoque is null)
            return NotFound();
        return await _context.Estoque.ToListAsync();
    }
    
    [HttpGet()]
    [Route("buscar/{EstoqueId}")]
    public async Task<ActionResult<Estoque>> Buscar([FromRoute] int EstoqueId)
    {
        if(_context.Estoque is null)
            return NotFound();
        var estoque = await _context.Estoque.FindAsync(EstoqueId);
        if (estoque is null)
            return NotFound();
        return estoque;
    }

    [HttpPost]
    [Route("cadastrar")]
    public IActionResult Cadastrar(Estoque estoque)
    {
        _context.Add(estoque);
        _context.SaveChanges();
        return Created("", estoque);
    }
    
    
   
[HttpPut("{id}")]
public async Task<IActionResult> PutEstoque(int id, Estoque eatoqueAtualizado)
{
    try
    {
        // Verifique se o estoque com o ID especificado existe no banco de dados
        var existingEstoque = await _context.Estoque.FindAsync(id);

        if (existingEstoque == null)
        {
            return NotFound($"Estoque com o ID {id} não encontrado.");
        }

        // Atualize as propriedades do estoque existente com os valores do novo estoque
        existingEstoque.Quantidade= estoqueAtualizado.Quantidade;

        await _context.SaveChangesAsync();

        return NoContent(); // Indica que a atualização foi bem-sucedida, sem conteúdo de resposta.
    }
    catch (Exception ex)
    {
        return StatusCode(500, $"Ocorreu um erro durante a atualização do estoque: {ex.Message}");
    }
}

    [HttpDelete()]
    [Route("excluir/{EstoqueId}")]
    public async Task<ActionResult> Excluir(int EstoqueId)
    {
        if(_context is null) return NotFound();
        if(_context.Estoque is null) return NotFound();
        var estoqueTemp = await _context.Estoque.FindAsync(EstoqueId);
        if(estoqueTemp is null) return NotFound();
        _context.Remove(estoqueTemp);
        await _context.SaveChangesAsync();
        return Ok();
    }

}





