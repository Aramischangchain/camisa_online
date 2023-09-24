using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Data;
using Microsoft.EntityFrameworkCore;
namespace WebApplication1.Controllers;

[ApiController]
[Route("[controller]")]
public class ItemPedidoController : ControllerBase
{
    private LojaDbContext? _context;

    public ItemPedidoController(LojaDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<ItemPedido>>> Listar()
    {
        if(_context.ItemPedido is null)
            return NotFound();
        return await _context.ItemPedido.ToListAsync();
    }
    
    [HttpGet()]
    [Route("buscar/{descricao}")]
    public async Task<ActionResult<ItemPedido>> Buscar([FromRoute] string descricao)
    {
        if(_context.ItemPedido is null)
            return NotFound();
        var item = await _context.ItemPedido.FindAsync(descricao);
        if (item is null)
            return NotFound();
        return item;
    }
    [HttpPost]
    [Route("cadastrar")]
    public IActionResult Cadastrar(ItemPedido item)
    {
        _context.Add(item);
        _context.SaveChanges();
        return Created("", item);
    }
    
    [HttpPut()]
    [Route("alterar")]
    public async Task<ActionResult> Alterar(ItemPedido item)
    {
        if(_context is null) return NotFound();
        if(_context.ItemPedido is null) return NotFound();
        var itemTemp = await _context.ItemPedido.FindAsync(item.Descricao);
        if(itemTemp is null) return NotFound();       
        _context.ItemPedido.Update(item);
        await _context.SaveChangesAsync();
        return Ok();
    }
    
}





