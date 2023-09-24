using WebApplication1.Data;
using WebApplication1.Models;
using Microsoft.AspNetCore.Mvc;
namespace WebApplication1.Controllers;


namespace WebApplication1.Controller;

[ApiController]
[Route("[controller]")]
public class ClienteController : ControllerBase
{
    private LojaDbContext? _context;

    public ClienteController(LojaDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Cliente>>> Listar()
    {
        if(_context.Cliente is null)
            return NotFound();
        return await _context.Cliente.ToListAsync();
    }
    [HttpGet()]
    [Route("buscar/{nome}")]
    public async Task<ActionResult<Cliente>> Buscar([FromRoute] string nome)
    {
        if(_context.Cliente is null)
            return NotFound();
        var cliente = await _context.Cliente.FindAsync(nome);
        if (cliente is null)
            return NotFound();
        return cliente;
    }
    [HttpPost]
    [Route("cadastrar")]
    public IActionResult Cadastrar(Cliente cliente)
    {
        _context.Add(cliente);
        _context.SaveChanges();
        return Created("", cliente);
    }
    
    [HttpPut]
    [Route("alterar/{nome}")]
    public async Task<ActionResult> Alterar(Cliente cliente)
    {
        if(_context is null) return NotFound();
        if(_context.Cliente is null) return NotFound();
        var clienteTemp = await _context.Cliente.FindAsync(cliente.Nome);
        if(clienteTemp is null) return NotFound();
        _context.Cliente.Update(cliente);
        await _context.SaveChangesAsync();
        return Ok();
    }
    
}





