using culinary_tour.Core.Context;
using culinary_tour.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace culinary_tour_blazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuisinesController : ControllerBase
    {
        private readonly ProjectContext _context;
        private readonly ILogger<WeatherForecastController> _logger;
        public CuisinesController(ProjectContext context, ILogger<WeatherForecastController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<Cuisine>> GetAllAsync()
        {
            return await _context.Cuisines.
                ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<Cuisine> GetAsync(int id)
        {
            return await _context.Cuisines.FirstAsync(x => x.Id == id);
        }

        [HttpPost]
        public async Task CreateAsync(Cuisine entity)
        {
            await _context.Cuisines.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        [HttpPut]
        public async Task UpdateAsync(Cuisine entity)
        {
            _context.Cuisines.Update(entity);
            await _context.SaveChangesAsync();
        }


        [HttpDelete("{id}")]
        public async Task DeleteAsync(int id)
        {
            _context.Cuisines.Remove(await _context.Cuisines.FindAsync(id));
            await _context.SaveChangesAsync();

        }
    }
}
