using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using Microsoft.EntityFrameworkCore;
namespace WebApplication1.Controllers;

[ApiController]
[Route("[controller]")]
public class ClienteController : ControllerBase
{
    private LojaDbContext? _context;

    public ClienteController(LojaDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Cliente>>> Listar()
    {
        if(_context.Cliente is null)
            return NotFound();
        return await _context.Cliente.ToListAsync();
    }
    
    [HttpGet()]
    [Route("buscar/{ClienteId}")]
    public async Task<ActionResult<Cliente>> Buscar([FromRoute] int ClienteId)
    {
        if(_context.Cliente is null)
            return NotFound();
        var cliente = await _context.Cliente.FindAsync(ClienteId);
        if (cliente is null)
            return NotFound();
        return cliente;
    }
    
    [HttpPost]
    [Route("cadastrar")]
    public IActionResult Cadastrar(Cliente cliente)
    {
        _context.Add(cliente);
        _context.SaveChanges();
        return Created("", cliente);
    }
    
   
    [HttpDelete()]
    [Route("excluir/{ClienteId}")]
    public async Task<ActionResult> Excluir(int ClienteId)
    {
        if(_context is null) return NotFound();
        if(_context.Cliente is null) return NotFound();
        var clienteTemp = await _context.Cliente.FindAsync(ClienteId);
        if(clienteTemp is null) return NotFound();
        _context.Remove(clienteTemp);
        await _context.SaveChangesAsync();
        return Ok();
    }


    [HttpPut("{id}")]
public async Task<IActionResult> PutCliente(int id, Cliente clienteAtualizado)
{
    try
    {
        // Verifique se o cliente com o ID especificado existe no banco de dados
        var existingCliente = await _context.Cliente.FindAsync(id);

        if (existingCliente == null)
        {
            return NotFound($"Cliente com o ID {id} não encontrado.");
        }

        // Atualize as propriedades do cliente existente com os valores do novo cliente
        existingCliente.Nome = clienteAtualizado.Nome;
        existingCliente.Email = clienteAtualizado.Email;
        existingCliente.Endereco = clienteAtualizado.Endereco;

        await _context.SaveChangesAsync();

        return NoContent(); // Indica que a atualização foi bem-sucedida, sem conteúdo de resposta.
    }
    catch (Exception ex)
    {
        return StatusCode(500, $"Ocorreu um erro durante a atualização do cliente: {ex.Message}");
    }
}

}





