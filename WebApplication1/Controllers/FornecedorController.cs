using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Data;
using Microsoft.EntityFrameworkCore;
namespace WebApplication1.Controllers;

[ApiController]
[Route("[controller]")]
public class FornecedorController : ControllerBase
{
    private LojaDbContext? _context;

    public FornecedorController(LojaDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Fornecedor>>> Listar()
    {
        if(_context.Fornecedor is null)
            return NotFound();
        return await _context.Fornecedor.ToListAsync();
    }
    
    [HttpGet()]
    [Route("buscar/{nome}")]
    public async Task<ActionResult<Fornecedor>> Buscar([FromRoute] string nome)
    {
        if(_context.Fornecedor is null)
            return NotFound();
        var forncedor = await _context.Fornecedor.FindAsync(nome);
        if (forncedor is null)
            return NotFound();
        return forncedor;
    }
    [HttpPost]
    [Route("cadastrar")]
    public IActionResult Cadastrar(Fornecedor fornecedor)
    {
        _context.Add(fornecedor);
        _context.SaveChanges();
        return Created("", fornecedor);
    }
    
    [HttpPut()]
    [Route("alterar")]
    public async Task<ActionResult> Alterar(Fornecedor fornecedor)
    {
        if(_context is null) return NotFound();
        if(_context.Fornecedor is null) return NotFound();
        var fornecedorTemp = await _context.Fornecedor.FindAsync(fornecedor.Nome);
        if(fornecedorTemp is null) return NotFound();       
        _context.Fornecedor.Update(fornecedor);
        await _context.SaveChangesAsync();
        return Ok();
    }
    
}





