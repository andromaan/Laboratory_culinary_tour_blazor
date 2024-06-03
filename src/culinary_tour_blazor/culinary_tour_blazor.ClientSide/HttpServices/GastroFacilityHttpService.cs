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

        public async Task<List<GastroFacility>> GetAllAsync()
        {
            var items = await _httpClient.GetFromJsonAsync<List<GastroFacility>>("/api/GastroFacility");
            return items;
        }

        public async Task AddAsync(GastroFacility item)
        {
            await _httpClient.PostAsJsonAsync("/api/GastroFacility", item);
        }

        public async Task UpdateAsync(GastroFacility item)
        {
            await _httpClient.PutAsJsonAsync($"/api/GastroFacility", item);
        }

        public async Task<GastroFacility> GetById(Guid id)
        {
            var result = await _httpClient
                .GetFromJsonAsync<GastroFacility>($"/api/GastroFacility/{id}");
            return result;
        }

        public async Task DeleteAsync(Guid id)
        {
            await _httpClient.DeleteAsync($"/api/GastroFacility/{id}");
        }
    }
}
