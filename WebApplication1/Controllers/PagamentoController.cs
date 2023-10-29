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
    
[HttpPut("{id}")]
public async Task<IActionResult> PutPagamento(int id, Pagamento pagamentoAtualizado)
{
    try
    {
        // Verifique se o Pagamento com o ID especificado existe no banco de dados
        var existingPagamento = await _context.Pagamento.FindAsync(id);

        if (existingPagamento == null)
        {
            return NotFound($"Pagamento com o ID {id} não encontrado.");
        }

        // Atualize as propriedades do pagamento existente com os valores do novo pagamento
        existingPagamento.NomeTitular= pagamentoAtualizado.NomeTitular;
        existingPagamento.NumeroCartao= pagamentoAtualizado.NumeroCartao;
        existingPagamento.Validade= pagamentoAtualizado.Validade;

        await _context.SaveChangesAsync();

        return NoContent(); // Indica que a atualização foi bem-sucedida, sem conteúdo de resposta.
    }
    catch (Exception ex)
    {
        return StatusCode(500, $"Ocorreu um erro durante a atualização do pagamento: {ex.Message}");
    }
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





