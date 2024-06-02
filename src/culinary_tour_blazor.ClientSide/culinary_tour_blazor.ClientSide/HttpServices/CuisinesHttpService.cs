using culinary_tour_blazor.ClientSide.Entities;
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
    }
}
