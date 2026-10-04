using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

Console.OutputEncoding = Encoding.UTF8;

const string endpoint = "https://api.disneyapi.dev/character/423";

Console.WriteLine("Consultando personagem da Disney...");
Console.WriteLine(endpoint);
Console.WriteLine();

using HttpClient client = new();

try
{
    HttpResponseMessage response = await client.GetAsync(endpoint);
    response.EnsureSuccessStatusCode();

    string json = await response.Content.ReadAsStringAsync();

    DisneyApiResponse? disneyResponse =
        JsonSerializer.Deserialize<DisneyApiResponse>(json);

    if (disneyResponse?.Data is not null)
    {
        Console.WriteLine("Nome:");
        Console.WriteLine(disneyResponse.Data.Name);
        Console.WriteLine();

        Console.WriteLine("Imagem:");
        Console.WriteLine(disneyResponse.Data.ImageUrl);
    }
    else
    {
        Console.WriteLine("Não foi possível obter os dados do personagem.");
    }
}
catch (HttpRequestException ex)
{
    Console.WriteLine("Erro ao acessar a Disney API.");
    Console.WriteLine($"Detalhes: {ex.Message}");
}
catch (JsonException ex)
{
    Console.WriteLine("Erro ao interpretar os dados retornados pela API.");
    Console.WriteLine($"Detalhes: {ex.Message}");
}

public class DisneyApiResponse
{
    [JsonPropertyName("data")]
    public DisneyCharacter? Data { get; set; }
}

public class DisneyCharacter
{
    [JsonPropertyName("_id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("imageUrl")]
    public string? ImageUrl { get; set; }
}
