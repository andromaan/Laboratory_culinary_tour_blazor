using culinary_tour_blazor.Server.Core;
using culinary_tour_blazor.Server.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace culinary_tour_blazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GastroFacilityController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly ILogger<WeatherForecastController> _logger;
        public GastroFacilityController(DataContext context, ILogger<WeatherForecastController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<GastroFacility>> GetAllAsync()
        {
            return await _context.GastroFacilities.
                Include(x => x.Type).
                Include("Cuisines").
                ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<GastroFacility> GetAsync(Guid id)
        {
            return await _context.GastroFacilities.Include(x => x.Type).
                Include("Cuisines").FirstAsync(x => x.Id == id);
        }

        [HttpPost]
        public async Task CreateAsync(GastroFacility entity)
        {
            await _context.GastroFacilities.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        [HttpPut]
        public async Task UpdateAsync(GastroFacility entity)
        {
            _context.GastroFacilities.Update(entity);
            await _context.SaveChangesAsync();
        }

        [HttpDelete("{id}")]
        public async Task DeleteAsync(Guid id)
        {
            _context.GastroFacilities.Remove(await _context.GastroFacilities.FindAsync(id));
            await _context.SaveChangesAsync();

        }
    }
}
