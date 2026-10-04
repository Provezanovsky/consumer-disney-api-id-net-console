# Consumer Disney API por ID

Aplicação console em C#/.NET criada para consumir a Disney API e consultar um personagem pelo ID.

## Objetivo

Consumir o endpoint:

`https://api.disneyapi.dev/character/423`

O ID `423` corresponde ao personagem **Big Bad Wolf**.

A aplicação lê o JSON retornado pela API e exibe no console:

- Nome do personagem
- URL da imagem do personagem

## Exemplo de saída

```text
Consultando personagem da Disney...
https://api.disneyapi.dev/character/423

Nome:
Big Bad Wolf

Imagem:
https://static.wikia.nocookie.net/disney/images/7/73/The_Big_Bad_Wolf.png
```

## Tecnologias utilizadas

- C#
- .NET 8
- HttpClient
- System.Text.Json

## Como executar

Com o SDK do .NET instalado, execute:

```bash
dotnet run
```
