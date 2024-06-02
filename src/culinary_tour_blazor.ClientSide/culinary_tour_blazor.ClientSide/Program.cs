using culinary_tour_blazor.ClientSide.HttpServices;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace culinary_tour_blazor.ClientSide
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddTransient<GastroFacilityHttpService>();
            builder.Services.AddTransient<FacilityTypesHttpService>();
            builder.Services.AddTransient<CuisinesHttpService>();

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7008/") });

            await builder.Build().RunAsync();
        }
    }
}
