
using System.Text.Json;
using API.DataTransferObjects;

namespace API.Services
{
    public class PlantNetService : IPlantIDService
    {
        private string url = "https://my-api.plantnet.org/v2/identify/all";
        private readonly string _apiKey;
        private readonly HttpClient _httpClient;

        public PlantNetService(IHttpClientFactory httpClientFactory, IConfiguration config)
        {
            _httpClient = httpClientFactory.CreateClient();
            _apiKey = config["PlantNet:ApiKey"] ?? throw new Exception("Plant Net API key is missing!");
        }

        public async Task<PlantIDDTO> IdentifyPlantAsync(IFormFile file)
        {
            using var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            memoryStream.Seek(0, SeekOrigin.Begin);

            var content = new MultipartFormDataContent();
            content.Add(new StreamContent(memoryStream), "images", file.FileName);
            content.Add(new StringContent("flower"), "organs");

            string queryParams = $"include-related-images=true&no-reject=false&nb-results=10&lang=en&api-key={_apiKey}";
            var response = await _httpClient.PostAsync($"{url}?{queryParams}", content);
            var responseBody = await response.Content.ReadAsStringAsync();
            try
            {
                var result = JsonSerializer.Deserialize<PlantIDDTO>(responseBody, new JsonSerializerOptions { PropertyNameCaseInsensitive = true});
                return result ?? throw new Exception("Failed to parse PlantNet response");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
