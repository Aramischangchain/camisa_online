using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
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
    [Route("buscar/{PedidoId}")]
    public async Task<ActionResult<Pedido>> Buscar([FromRoute] int CarrinhoId)
    {
        if(_context.Pedido is null)
            return NotFound();
        var pedido = await _context.Pedido.FindAsync(CarrinhoId);
        if (pedido is null)
            return NotFound();
        return pedido;
    }
    
    [HttpPost]
    [Route("cadastrar")]
    public IActionResult Cadastrar(Pedido carrinho)
    {
        _context.Add(carrinho);
        _context.SaveChanges();
        return Created("", carrinho);
    }



    [HttpDelete()]
    [Route("excluir/{PedidoId}")]
    public async Task<ActionResult> Excluir(int CarrinhoId)
    {
        if(_context is null) return NotFound();
        if(_context.Pedido is null) return NotFound();
        var pedidoTemp = await _context.Pedido.FindAsync(CarrinhoId);
        if(pedidoTemp is null) return NotFound();
        _context.Remove(pedidoTemp);
        await _context.SaveChangesAsync();
        return Ok();
    }

[HttpPut("{id}")]
public async Task<IActionResult> PutPedido(int id, Pedido pedidoAtualizado)
{
    try
    {
        // Verifique se o carrinho com o ID especificado existe no banco de dados
        var existingPedido = await _context.Pedido.FindAsync(id);

        if (existingPedido == null)
        {
            return NotFound($"Pedido com o ID {id} não encontrado.");
        }

        // Atualize as propriedades do carrinho existente com os valores do novo carrinho
        existingPedido.Status = pedidoAtualizado.Status;
        existingPedido.Preco = pedidoAtualizado.Preco;

        await _context.SaveChangesAsync();

        return NoContent(); // Indica que a atualização foi bem-sucedida, sem conteúdo de resposta.
    }
    catch (Exception ex)
    {
        return StatusCode(500, $"Ocorreu um erro durante a atualização do pedido: {ex.Message}");
    }
}

}





