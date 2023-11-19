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

    [HttpPost]
    [Route("cadastrar")]
    public IActionResult Cadastrar(ItemPedido item)
    {
        _context.Add(item);
        _context.SaveChanges();
        return Created("", item);
    }
    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<ItemPedido>>> Listar()
    {
        if (_context.ItemPedido is null)
            return NotFound();
        return await _context.ItemPedido.ToListAsync();
    }

    [HttpGet()]
    [Route("buscar/{ItemPedidoId}")]
    public async Task<ActionResult<ItemPedido>> Buscar([FromRoute] int ItemPedidoId)
    {
        if (_context.ItemPedido is null)
            return NotFound();
        var item = await _context.ItemPedido.FindAsync(ItemPedidoId);
        if (item is null)
            return NotFound();
        return item;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutItemPedido(int id, ItemPedido itemAtualizado)
    {
        try
        {
            // Verifique se o Item com o ID especificado existe no banco de dados
            var existingItem = await _context.ItemPedido.FindAsync(id);

            if (existingItem == null)
            {
                return NotFound($"Item com o ID {id} não encontrado.");
            }

            // Atualize as propriedades do Item existente com os valores do novo Item
            existingItem.Descricao = itemAtualizado.Descricao;
            existingItem.Quantidade = itemAtualizado.Quantidade;



            await _context.SaveChangesAsync();

            return NoContent(); // Indica que a atualização foi bem-sucedida, sem conteúdo de resposta.
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Ocorreu um erro durante a atualização do Item: {ex.Message}");
        }
    }
    [HttpDelete()]
    [Route("excluir/{ItemPedidoId}")]
    public async Task<ActionResult> Excluir(int ItemPedidoId)
    {
        if (_context is null) return NotFound();
        if (_context.ItemPedido is null) return NotFound();
        var itempedidoTemp = await _context.ItemPedido.FindAsync(ItemPedidoId);
        if (itempedidoTemp is null) return NotFound();
        _context.Remove(itempedidoTemp);
        await _context.SaveChangesAsync();
        return Ok();
    }


}





