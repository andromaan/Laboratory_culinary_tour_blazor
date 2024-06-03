using culinary_tour.Core.Entities;
using System.Net.Http.Json;

namespace culinary_tour_blazor.ClientSide.HttpServices
{
    public class FacilityTypesHttpService
    {
        private readonly HttpClient _httpClient;

        public FacilityTypesHttpService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<List<FacilityType>> GetAllAsync()
        {
            var items = await _httpClient.GetFromJsonAsync<List<FacilityType>>("/api/FacilityType");
            return items;
        }

        public async Task AddAsync(FacilityType item)
        {
            await _httpClient.PostAsJsonAsync("/api/FacilityType", item);
        }

        public async Task UpdateAsync(FacilityType item)
        {
            await _httpClient.PutAsJsonAsync($"/api/FacilityType", item);
        }

        public async Task<FacilityType> GetById(int id)
        {
            var result = await _httpClient
                .GetFromJsonAsync<FacilityType>($"/api/FacilityType/{id}");
            return result;
        }

        public async Task DeleteAsync(int id)
        {
            await _httpClient.DeleteAsync($"/api/FacilityType/{id}");
        }
    }
}
