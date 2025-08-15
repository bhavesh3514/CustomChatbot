using CustomChatbot.Configuration;
using CustomChatbot.Interfaces;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace CustomChatbot.Services
{
    public class OpenRouterService : IOpenRouterService
    {
        private readonly OpenRouterConfiguration _config;
        private readonly HttpClient _httpClient;

        public OpenRouterService(IOptions<OpenRouterConfiguration> config)
        {
            _config = config.Value;
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", _config.ApiKey);
        }

        public async Task<string> GetChatResponseAsync(string prompt)
        {
            var requestBody = new
            {
                model = _config.Model,
                messages = new[]
                {
                    new { role = "user", content = prompt }
                }
            };

            var content = new StringContent(
                JsonSerializer.Serialize(requestBody),
                Encoding.UTF8,
                "application/json"
            );

            var response = await _httpClient.PostAsync(_config.ApiUrl, content);
            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            using var doc = JsonDocument.Parse(jsonResponse);

            return doc.RootElement
                .GetProperty("choices")[0]
                .GetProperty("message")
                .GetProperty("content")
                .GetString() ?? "No response from model.";
        }
    }
}
