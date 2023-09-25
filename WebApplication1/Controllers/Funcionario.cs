using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Data;
using Microsoft.EntityFrameworkCore;
namespace WebApplication1.Controllers;

[ApiController]
[Route("[controller]")]
public class FuncionarioController : ControllerBase
{
    private LojaDbContext? _context;

    public FuncionarioController(LojaDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Funcionario>>> Listar()
    {
        if(_context.Funcionario is null)
            return NotFound();
        return await _context.Funcionario.ToListAsync();
    }
    
    [HttpGet()]
    [Route("buscar/{FuncionarioId}")]
    public async Task<ActionResult<Funcionario>> Buscar([FromRoute] int FuncionarioId)
    {
        if(_context.Funcionario is null)
            return NotFound();
        var funcionario = await _context.Funcionario.FindAsync(FuncionarioId);
        if (funcionario is null)
            return NotFound();
        return funcionario;
    }
    [HttpPost]
    [Route("cadastrar")]
    public IActionResult Cadastrar(Funcionario funcionario)
    {
        _context.Add(funcionario);
        _context.SaveChanges();
        return Created("", funcionario);
    }
    
    [HttpPut()]
    [Route("alterar")]
    public async Task<ActionResult> Alterar(Funcionario funcionario)
    {
        if(_context is null) return NotFound();
        if(_context.Funcionario is null) return NotFound();
        var funcionarioTemp = await _context.Funcionario.FindAsync(funcionario.Nome);
        if(funcionarioTemp is null) return NotFound();       
        _context.Funcionario.Update(funcionario);
        await _context.SaveChangesAsync();
        return Ok();
    }
    
}





