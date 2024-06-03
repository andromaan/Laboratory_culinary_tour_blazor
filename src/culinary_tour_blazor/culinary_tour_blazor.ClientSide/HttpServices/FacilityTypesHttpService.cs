using culinary_tour_blazor.ClientSide.Entities;
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

        public async Task<List<FacilityTypeItem>> GetAllAsync()
        {
            var items = await _httpClient.GetFromJsonAsync<List<FacilityTypeItem>>("/api/FacilityType");
            return items;
        }
    }
}
