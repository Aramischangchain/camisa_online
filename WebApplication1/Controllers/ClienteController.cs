using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Data;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Controllers;

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
}





