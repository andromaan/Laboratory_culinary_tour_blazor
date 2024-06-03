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
    }
}
