using culinary_tour_blazor.ClientSide.Entities;
using System.Net.Http.Json;

namespace culinary_tour_blazor.ClientSide.HttpServices
{
    public class GastroFacilityHttpService
    {
        private readonly HttpClient _httpClient;

        public GastroFacilityHttpService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<List<GastroFacilityItem>> GetAllAsync()
        {
            var items = await _httpClient.GetFromJsonAsync<List<GastroFacilityItem>>("/api/GastroFacility");
            return items;
        }

        public async Task AddAsync(GastroFacilityItem item)
        {
            var newItem = await _httpClient.PostAsJsonAsync<GastroFacilityItem>("/api/GastroFacility", item);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _httpClient.DeleteAsync($"/api/GastroFacility/{id}");
        }
    }
}
