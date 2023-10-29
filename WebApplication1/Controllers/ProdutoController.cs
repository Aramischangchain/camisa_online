using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Data;
using Microsoft.EntityFrameworkCore;
namespace WebApplication1.Controllers;

[ApiController]
[Route("[controller]")]
public class ProdutoController : ControllerBase
{
    private LojaDbContext? _context;

    public ProdutoController(LojaDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Produto>>> Listar()
    {
        if(_context.Produto is null)
            return NotFound();
        return await _context.Produto.ToListAsync();
    }
    
    [HttpGet()]
    [Route("buscar/{ProdutoId}")]
    public async Task<ActionResult<Produto>> Buscar([FromRoute] string ProdutoId)
    {
        if(_context.Produto is null)
            return NotFound();
        var produto = await _context.Produto.FindAsync(ProdutoId);
        if (produto is null)
            return NotFound();
        return produto;
    }
    [HttpPost]
    [Route("cadastrar")]
    public IActionResult Cadastrar(Produto produto)
    {
        _context.Add(produto);
        _context.SaveChanges();
        return Created("", produto);
    }
    
[HttpPut("{id}")]
public async Task<IActionResult> PutProduto(int id, Produto produtoAtualizado)
{
    try
    {
        // Verifique se o produto com o ID especificado existe no banco de dados
        var existingProduto = await _context.Produto.FindAsync(id);

        if (existingProduto == null)
        {
            return NotFound($"Produto com o ID {id} não encontrado.");
        }

        // Atualize as propriedades do produto existente com os valores do novo produto
        existingProduto.Descricao= produtoAtualizado.Descricao;
        existingProduto.Cor= produtoAtualizado.Cor;
        existingProduto.Preco= produtoAtualizado.Preco;
        existingProduto.Tamanho= produtoAtualizado.Tamanho;

        await _context.SaveChangesAsync();

        return NoContent(); // Indica que a atualização foi bem-sucedida, sem conteúdo de resposta.
    }
    catch (Exception ex)
    {
        return StatusCode(500, $"Ocorreu um erro durante a atualização do fornecedor: {ex.Message}");
    }
}

    [HttpDelete()]
    [Route("excluir/{ProdutoId}")]
    public async Task<ActionResult> Excluir(int ProdutoId)
    {
        if(_context is null) return NotFound();
        if(_context.Produto is null) return NotFound();
        var produtoTemp = await _context.Produto.FindAsync(ProdutoId);
        if(produtoTemp is null) return NotFound();
        _context.Remove(produtoTemp);
        await _context.SaveChangesAsync();
        return Ok();
    }

}





