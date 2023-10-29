using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Data;
using Microsoft.EntityFrameworkCore;
namespace WebApplication1.Controllers;

[ApiController]
[Route("[controller]")]
public class FornecedorController : ControllerBase
{
    private LojaDbContext? _context;

    public FornecedorController(LojaDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Fornecedor>>> Listar()
    {
        if (_context.Fornecedor is null)
            return NotFound();
        return await _context.Fornecedor.ToListAsync();
    }

    [HttpGet()]
    [Route("buscar/{FornecedorId}")]
    public async Task<ActionResult<Fornecedor>> Buscar([FromRoute] int FornecedorId)
    {
        if (_context.Fornecedor is null)
            return NotFound();
        var forncedor = await _context.Fornecedor.FindAsync(FornecedorId);
        if (forncedor is null)
            return NotFound();
        return forncedor;
    }
    [HttpPost]
    [Route("cadastrar")]
    public IActionResult Cadastrar(Fornecedor fornecedor)
    {
        _context.Add(fornecedor);
        _context.SaveChanges();
        return Created("", fornecedor);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutFornecedor(int id, Fornecedor fornecedorAtualizado)
    {
        try
        {
            // Verifique se o fornecedor com o ID especificado existe no banco de dados
            var existingFornecedor = await _context.Fornecedor.FindAsync(id);

            if (existingFornecedor == null)
            {
                return NotFound($"Fornecedor com o ID {id} não encontrado.");
            }

            // Atualize as propriedades do fornecedor existente com os valores do novo fornedor
            existingFornecedor.Nome = fornecedorAtualizado.Nome;
            existingFornecedor.Contato = fornecedorAtualizado.Contato;
            existingFornecedor.Endereco = fornecedorAtualizado.Endereco;



            await _context.SaveChangesAsync();

            return NoContent(); // Indica que a atualização foi bem-sucedida, sem conteúdo de resposta.
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Ocorreu um erro durante a atualização do fornecedor: {ex.Message}");
        }
    }


    [HttpDelete()]
    [Route("excluir/{FornecedorId}")]
    public async Task<ActionResult> Excluir(int FornecedorId)
    {
        if (_context is null) return NotFound();
        if (_context.Fornecedor is null) return NotFound();
        var fornecedorTemp = await _context.Fornecedor.FindAsync(FornecedorId);
        if (fornecedorTemp is null) return NotFound();
        _context.Remove(fornecedorTemp);
        await _context.SaveChangesAsync();
        return Ok();
    }


}





