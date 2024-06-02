using culinary_tour_blazor.Server.Core.Entities;
using culinary_tour_blazor.Server.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace culinary_tour_blazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacilityTypeController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly ILogger<WeatherForecastController> _logger;
        public FacilityTypeController(DataContext context, ILogger<WeatherForecastController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<FacilityType>> GetAllAsync()
        {
            return await _context.FacilityTypes.
                ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<FacilityType> GetAsync(int id)
        {
            return await _context.FacilityTypes.FirstAsync(x => x.Id == id);
        }

        [HttpPost]
        public async Task CreateAsync(FacilityType entity)
        {
            await _context.FacilityTypes.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        [HttpPut]
        public async Task UpdateAsync(FacilityType entity)
        {
            _context.FacilityTypes.Update(entity);
            await _context.SaveChangesAsync();
        }

        [HttpDelete("{id}")]
        public async Task DeleteAsync(int id)
        {
            _context.FacilityTypes.Remove(await _context.FacilityTypes.FindAsync(id));
            await _context.SaveChangesAsync();

        }
    }
}
