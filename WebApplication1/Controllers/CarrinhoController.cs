using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
namespace WebApplication1.Controllers;

[ApiController]
[Route("[controller]")]
public class CarrinhoController : ControllerBase
{
    private LojaDbContext? _context;

    public CarrinhoController(LojaDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Carrinho>>> Listar()
    {
        if(_context.Carrinho is null)
            return NotFound();
        return await _context.Carrinho.ToListAsync();
    }
    
    [HttpGet()]
    [Route("buscar/{CarrinhoId}")]
    public async Task<ActionResult<Carrinho>> Buscar([FromRoute] int CarrinhoId)
    {
        if(_context.Carrinho is null)
            return NotFound();
        var carrinho = await _context.Carrinho.FindAsync(CarrinhoId);
        if (carrinho is null)
            return NotFound();
        return carrinho;
    }
    
    [HttpPost]
    [Route("cadastrar")]
    public IActionResult Cadastrar(Carrinho carrinho)
    {
        _context.Add(carrinho);
        _context.SaveChanges();
        return Created("", carrinho);
    }



    [HttpDelete()]
    [Route("excluir/{CarrinhoId}")]
    public async Task<ActionResult> Excluir(int CarrinhoId)
    {
        if(_context is null) return NotFound();
        if(_context.Carrinho is null) return NotFound();
        var carrinhoTemp = await _context.Carrinho.FindAsync(CarrinhoId);
        if(carrinhoTemp is null) return NotFound();
        _context.Remove(carrinhoTemp);
        await _context.SaveChangesAsync();
        return Ok();
    }


}





