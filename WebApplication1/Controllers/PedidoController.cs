using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Data;
using Microsoft.EntityFrameworkCore;
namespace WebApplication1.Controllers;

[ApiController]
[Route("[controller]")]
public class PedidoController : ControllerBase
{
    private LojaDbContext? _context;

    public PedidoController(LojaDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Pedido>>> Listar()
    {
        if(_context.Pedido is null)
            return NotFound();
        return await _context.Pedido.ToListAsync();
    }
    
    [HttpGet()]
    [Route("buscar/{numero}")]
    public async Task<ActionResult<Pedido>> Buscar([FromRoute] string numero)
    {
        if(_context.Pedido is null)
            return NotFound();
        var pedido = await _context.Pedido.FindAsync(numero);
        if (pedido is null)
            return NotFound();
        return pedido;
    }
    [HttpPost]
    [Route("cadastrar")]
    public IActionResult Cadastrar(Pedido pedido)
    {
        _context.Add(pedido);
        _context.SaveChanges();
        return Created("", pedido);
    }
    
    [HttpPut()]
    [Route("alterar")]
    public async Task<ActionResult> Alterar(Pedido pedido)
    {
        if(_context is null) return NotFound();
        if(_context.Pedido is null) return NotFound();
        var pedidoTemp = await _context.Pedido.FindAsync(pedido.Numero);
        if(pedidoTemp is null) return NotFound();       
        _context.Pedido.Update(pedido);
        await _context.SaveChangesAsync();
        return Ok();
    }
    
}





