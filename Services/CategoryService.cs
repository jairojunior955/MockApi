using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using MockApi.Models;

namespace MockApi.Services
{
    // CategoryServices.cs
    public class CategoryService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl;

        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _apiBaseUrl = Environment.GetEnvironmentVariable("API_BASE_URL");
            if (string.IsNullOrEmpty(_apiBaseUrl))
            {
                throw new InvalidOperationException("API_BASE_URL environment variable is not set.");
            }
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Category>>(_apiBaseUrl);
        }

        public async Task<Category> GetCategoryByIdAsync(string id)
        {
            return await _httpClient.GetFromJsonAsync<Category>($"{_apiBaseUrl}/{id}");
        }
    }

}
