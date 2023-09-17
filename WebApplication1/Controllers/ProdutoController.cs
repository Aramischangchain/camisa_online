using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

[Route("api/[controller]")]
[ApiController]
public class ProdutoController : ControllerBase
{
    private List<Produto> _produtos; // Substitua por acesso ao banco de dados ou armazenamento real.

    public ProdutoController()
    {
        // Inicialize a lista de produtos (simulando dados em memória).
        _produtos = new List<Produto>
        {
            new Produto { Id = 1, Nome = "Produto 1", Preco = 10.99m },
            new Produto { Id = 2, Nome = "Produto 2", Preco = 20.49m }
            // Adicione mais produtos conforme necessário.
        };
    }

    // GET api/produto
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_produtos);
    }

    // GET api/produto/1
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var produto = _produtos.FirstOrDefault(p => p.Id == id);

        if (produto == null)
        {
            return NotFound(); // Produto não encontrado.
        }

        return Ok(produto);
    }

    // POST api/produto
    [HttpPost]
    public IActionResult Post([FromBody] Produto produto)
    {
        produto.Id = _produtos.Max(p => p.Id) + 1; // Simulando a geração de um novo ID.
        _produtos.Add(produto);
        return CreatedAtAction(nameof(Get), new { id = produto.Id }, produto);
    }

    // PUT api/produto/1
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Produto produto)
    {
        var existingProduto = _produtos.FirstOrDefault(p => p.Id == id);

        if (existingProduto == null)
        {
            return NotFound(); // Produto não encontrado.
        }

        existingProduto.Nome = produto.Nome;
        existingProduto.Preco = produto.Preco;

        return NoContent();
    }

    // DELETE api/produto/1
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var produto = _produtos.FirstOrDefault(p => p.Id == id);

        if (produto == null)
        {
            return NotFound(); // Produto não encontrado.
        }

        _produtos.Remove(produto);
        return NoContent();
    }
}
