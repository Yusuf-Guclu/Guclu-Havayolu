using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Havayolu.Models;

public interface IGroqService
{
    Task<string> AskQuestion(string question);
}

public class GroqService : IGroqService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;

    public GroqService(IConfiguration configuration)
    {
        _httpClient = new HttpClient();
        _apiKey = configuration["Groq:ApiKey"];
        _httpClient.BaseAddress = new Uri("https://api.groq.com/v1/");
        _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");
    }

    public async Task<string> AskQuestion(string question)
    {
        var request = new
        {
            model = "mixtral-8x7b-32768",
            messages = new[]
            {
                new { role = "user", content = question }
            }
        };

        var response = await _httpClient.PostAsJsonAsync("chat/completions", request);
        response.EnsureSuccessStatusCode();

        var result = await response.Content.ReadFromJsonAsync<GroqResponse>();
        return result?.Choices?[0]?.Message?.Content ?? "Üzgünüm, bir cevap üretemiyorum.";
    }
} 