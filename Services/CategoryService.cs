using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using MockApi.Models;

namespace MockApi.Services
{
    public class CategoryService()
    {
        private readonly HttpClient _httpClient;

        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
    }   
}