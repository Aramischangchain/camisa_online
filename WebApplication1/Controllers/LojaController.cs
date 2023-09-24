using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Data;
using Microsoft.EntityFrameworkCore;
namespace WebApplication1.Controllers;

[ApiController]
[Route("[controller]")]
public class LojaController : ControllerBase
{
    private LojaDbContext? _context;

    public LojaController(LojaDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Loja>>> Listar()
    {
        if(_context.Loja is null)
            return NotFound();
        return await _context.Loja.ToListAsync();
    }
    
    [HttpGet()]
    [Route("buscar/{nome}")]
    public async Task<ActionResult<Loja>> Buscar([FromRoute] string nome)
    {
        if(_context.Loja is null)
            return NotFound();
        var loja = await _context.Loja.FindAsync(nome);
        if (loja is null)
            return NotFound();
        return loja;
    }
    [HttpPost]
    [Route("cadastrar")]
    public IActionResult Cadastrar(Loja loja)
    {
        _context.Add(loja);
        _context.SaveChanges();
        return Created("", loja);
    }
    
    [HttpPut()]
    [Route("alterar")]
    public async Task<ActionResult> Alterar(Loja loja)
    {
        if(_context is null) return NotFound();
        if(_context.Loja is null) return NotFound();
        var lojaTemp = await _context.Loja.FindAsync(loja.Nome);
        if(lojaTemp is null) return NotFound();       
        _context.Loja.Update(loja);
        await _context.SaveChangesAsync();
        return Ok();
    }
    
}





