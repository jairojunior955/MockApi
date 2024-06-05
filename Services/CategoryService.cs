using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using MockApi.Models;

namespace MockApi.Services
{
    public class CategoryService
    {
        private readonly HttpClient _httpClient;

        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Category>>("*");
        }

        public async Task<Category> GetCategoryByIdAsync(string id)
        {
            return await _httpClient.GetFromJsonAsync<Category>($"*");
        }
    }
}
