using culinary_tour.Core.Context;
using culinary_tour.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;

namespace culinary_tour_blazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GastroFacilityController : ControllerBase
    {
        private readonly ProjectContext _context;
        private readonly ILogger<WeatherForecastController> _logger;
        public GastroFacilityController(ProjectContext context, ILogger<WeatherForecastController> logger)
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
            try
            {
                var gf = new GastroFacility
                {
                    Name = entity.Name,
                    Description = entity.Description,
                    ImagePath = entity.ImagePath,
                    Photo = entity.Photo,
                    RatingAvg = entity.RatingAvg,
                    Type = entity.Type,
                    TypeId = entity.TypeId
                };

                foreach (var cuisine_2 in entity.Cuisines)
                {
                    var cuisine = await _context.Cuisines.FirstOrDefaultAsync(x=> x.Id == cuisine_2.Id);
                    if (cuisine != null)
                    {
                        gf.Cuisines.Add(cuisine);
                    }
                }

                await _context.GastroFacilities.AddAsync(gf);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching data: {ex.Message}");
            }
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
