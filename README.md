# camisa_online

Projeto da aula de terça-feira em C# para criar uma loja de camisetas online.

classes:

- Funcionário
- Fornecedor
- Loja
- Pedido
- Cliente
- Pagamento
- ItemPedido
- Produto
- Estoque

## 🏁 Usando

Clone o repositorio e vá para a raiz do diretório

```bash
$ git clone https://github.com/Aramischangchain/camisa_online.git

$ cd WebApplication1
```

Verifique a comptibilidade do seu ambiente
(.NET)

```bash
 dotnet --list-sdks
```

Verifique a versão do seu .NET (de preferência a versão 7.0.400)

```bash
 dotnet --version
```

Instale as dependências

```bash
 dotnet add package Microsoft.EntityFrameworkCore
 dotnet add package Microsoft.EntityFrameworkCore.Tools.DotNet
 dotnet add package Microsoft.EntityFrameworkCore.Design
 dotnet tool install --global dotnet-ef
 dotnet add package Microsoft.EntityFrameworkCore.Sqlite
```

Abra o projeto no diretorio rais WebApplication1:

```bash
 dotnet ef migrations add CriacaoInicial
```

Toda vez que houver alteração na model, criar novamigração e atualizar o BD:

```bash
 dotnet ef migrations add AlteradoTalCoisa
 dotnet ef database update
```

Execute o projeto no Visual Studio Code
<a href="https://github.com/Aramischangchain/camisa_online">
<img src="imagem drawio/diagrama.png" alt="diagrama de classes" width="1500" heigh="1500">
</a>
