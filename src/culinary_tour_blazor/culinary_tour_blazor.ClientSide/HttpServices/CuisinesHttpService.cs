using culinary_tour.Core.Entities;
using System.Net.Http.Json;

namespace culinary_tour_blazor.ClientSide.HttpServices
{
    public class CuisinesHttpService
    {
        private readonly HttpClient _httpClient;

        public CuisinesHttpService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<List<Cuisine>> GetAllAsync()
        {
            var items = await _httpClient.GetFromJsonAsync<List<Cuisine>>("/api/Cuisines");
            return items;
        }
        public async Task AddAsync(Cuisine item)
        {
            await _httpClient.PostAsJsonAsync("/api/Cuisines", item);
        }

        public async Task UpdateAsync(Cuisine item)
        {
            await _httpClient.PutAsJsonAsync($"/api/Cuisines", item);
        }

        public async Task<Cuisine> GetById(int id)
        {
            var result = await _httpClient
                .GetFromJsonAsync<Cuisine>($"/api/Cuisines/{id}");
            return result;
        }

        public async Task DeleteAsync(int id)
        {
            await _httpClient.DeleteAsync($"/api/Cuisines/{id}");
        }
    }
}
