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

    [HttpPut("{id}")]
    public async Task<IActionResult> PutCarrinho(int id, Carrinho carrinho)
    {
        if (id != carrinho.CarrinhoId)
        {
            return BadRequest("O ID do carrinho na rota não coincide com o ID do carrinho fornecido no corpo da solicitação.");
        }

        // Verifique se o carrinho com o ID especificado existe no banco de dados
        var existingCarrinho = await _context.Carrinho.FindAsync(id);

        if (existingCarrinho == null)
        {
            return NotFound("Carrinho não encontrado.");
        }

        try
        {
            // Atualize as propriedades do cliente existente com os valores do novo cliente
            existingCarrinho.Status = carrinho.Status;
            existingCarrinho.Preco = carrinho.Preco;

            _context.Entry(existingCarrinho).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            return Conflict("O carrinho foi modificado por outro usuário simultaneamente.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Ocorreu um erro durante a atualização do carrinho: {ex.Message}");
        }

        return NoContent(); // Indica que a atualização foi bem-sucedida, sem conteúdo de resposta.
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





