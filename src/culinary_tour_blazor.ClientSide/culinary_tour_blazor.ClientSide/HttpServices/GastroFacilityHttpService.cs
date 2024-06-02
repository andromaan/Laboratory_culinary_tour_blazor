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
            await _httpClient.PostAsJsonAsync("/api/GastroFacility", item);
        }

        public async Task UpdateAsync(GastroFacilityItem item)
        {
            await _httpClient.PutAsJsonAsync($"/api/GastroFacility", item);
        }

        public async Task<GastroFacilityItem> GetById(Guid id)
        {
            var result = await _httpClient
                .GetFromJsonAsync<GastroFacilityItem>($"/api/GastroFacility/{id}");
            return result;
        }

        public async Task DeleteAsync(Guid id)
        {
            await _httpClient.DeleteAsync($"/api/GastroFacility/{id}");
        }
    }
}
