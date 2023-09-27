using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Data;
using Microsoft.EntityFrameworkCore;
namespace WebApplication1.Controllers;

[ApiController]
[Route("[controller]")]
public class PagamentoController : ControllerBase
{
    private LojaDbContext? _context;

    public PagamentoController(LojaDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Pagamento>>> Listar()
    {
        if(_context.Pagamento is null)
            return NotFound();
        return await _context.Pagamento.ToListAsync();
    }
    
    [HttpGet()]
    [Route("buscar/{PagamentoId}")]
    public async Task<ActionResult<Pagamento>> Buscar([FromRoute] int PagamentoId)
    {
        if(_context.Pagamento is null)
            return NotFound();
        var pagamento = await _context.Pagamento.FindAsync(PagamentoId);
        if (pagamento is null)
            return NotFound();
        return pagamento;
    }
    [HttpPost]
    [Route("cadastrar")]
    public IActionResult Cadastrar(Pagamento pagamento)
    {
        _context.Add(pagamento);
        _context.SaveChanges();
        return Created("", pagamento);
    }
    
    [HttpPut()]
    [Route("alterar")]
    public async Task<ActionResult> Alterar(Pagamento pagamento)
    {
        if(_context is null) return NotFound();
        if(_context.Pagamento is null) return NotFound();
        var pagamentoTemp = await _context.Pagamento.FindAsync(pagamento.NumeroCartao);
        if(pagamentoTemp is null) return NotFound();       
        _context.Pagamento.Update(pagamento);
        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpDelete()]
    [Route("excluir/{PagamentoId}")]
    public async Task<ActionResult> Excluir(int PagamentoId)
    {
        if(_context is null) return NotFound();
        if(_context.Pagamento is null) return NotFound();
        var pagamentoTemp = await _context.Pagamento.FindAsync(PagamentoId);
        if(pagamentoTemp is null) return NotFound();
        _context.Remove(pagamentoTemp);
        await _context.SaveChangesAsync();
        return Ok();
    }

    
}





