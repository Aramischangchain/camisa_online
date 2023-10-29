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
    public async Task<ActionResult<IEnumerable<ItemCarrinho>>> Listar()
    {
        if (_context.ItemCarrinho is null)
            return NotFound();
        return await _context.ItemCarrinho.ToListAsync();
    }

    [HttpGet()]
    [Route("buscar/{ItemCarrinhoId}")]
    public async Task<ActionResult<ItemCarrinho>> Buscar([FromRoute] int ItemCarrinhoId)
    {
        if (_context.ItemCarrinho is null)
            return NotFound();
        var item = await _context.ItemCarrinho.FindAsync(ItemCarrinhoId);
        if (item is null)
            return NotFound();
        return item;
    }
    [HttpPost]
    [Route("cadastrar")]
    public IActionResult Cadastrar(ItemCarrinho item)
    {
        _context.Add(item);
        _context.SaveChanges();
        return Created("", item);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutItemCarrinho(int id, ItemCarrinho itemAtualizado)
    {
        try
        {
            // Verifique se o Item com o ID especificado existe no banco de dados
            var existingItem = await _context.ItemCarrinho.FindAsync(id);

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
    [Route("excluir/{ItemCarrinhoId}")]
    public async Task<ActionResult> Excluir(int ItemCarrinhoId)
    {
        if (_context is null) return NotFound();
        if (_context.ItemCarrinho is null) return NotFound();
        var itemcarrinhoTemp = await _context.ItemCarrinho.FindAsync(ItemCarrinhoId);
        if (itemcarrinhoTemp is null) return NotFound();
        _context.Remove(itemcarrinhoTemp);
        await _context.SaveChangesAsync();
        return Ok();
    }


}





