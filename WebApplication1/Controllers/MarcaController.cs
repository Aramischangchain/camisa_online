using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

[Route("api/[controller]")]
[ApiController]
public class MarcaController : ControllerBase
{
    private List<Marca> _marcas; // Substitua por acesso ao banco de dados ou armazenamento real.

    public MarcaController()
    {
        // Inicialize a lista de marcas (simulando dados em memória).
        _marcas = new List<Marca>
        {
            new Marca { Id = 1, Nome = "Marca 1" },
            new Marca { Id = 2, Nome = "Marca 2" }
            // Adicione mais marcas conforme necessário.
        };
    }

    // Métodos GET, POST, PUT e DELETE para a classe Marca
    // ...

}
