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
    
    [HttpPut()]
    [Route("alterar")]
    public async Task<ActionResult> Alterar(Estoque estoque)
    {
        if(_context is null) return NotFound();
        if(_context.Estoque is null) return NotFound();
        var estoqueTemp = await _context.Estoque.FindAsync(estoque.Descricao);
        if(estoqueTemp is null) return NotFound();       
        _context.Estoque.Update(estoque);
        await _context.SaveChangesAsync();
        return Ok();
    }
    
}





