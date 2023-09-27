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
    public async Task<IActionResult> PutEstoque(int id, Estoque estoque)
    {
        if (id != estoque.EstoqueId)
        {
            return BadRequest("O ID do estoque na rota não coincide com o ID do estoque fornecido no corpo da solicitação.");
        }

        // Verifique se o estoque com o ID especificado existe no banco de dados
        var EstoqueTemp = await _context.Estoque.FindAsync(id);

        if (EstoqueTemp == null)
        {
            return NotFound("Estoque não encontrado.");
        }

        try
        {
            // Atualize as propriedades do estoque existente com os valores do novo estoque
            EstoqueTemp.Quantidade = estoque.Quantidade;

            _context.Entry(EstoqueTemp).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            return Conflict("O estoque foi modificado por outro usuário simultaneamente.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Ocorreu um erro durante a atualização do estoque: {ex.Message}");
        }

        return NoContent(); // Indica que a atualização foi bem-sucedida, sem conteúdo de resposta.
    }
}





