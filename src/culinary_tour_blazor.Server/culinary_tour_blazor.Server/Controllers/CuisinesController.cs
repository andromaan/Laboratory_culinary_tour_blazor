﻿using culinary_tour_blazor.Server.Core.Entities;
using culinary_tour_blazor.Server.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace culinary_tour_blazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuisinesController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly ILogger<WeatherForecastController> _logger;
        public CuisinesController(DataContext context, ILogger<WeatherForecastController> logger)
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
    }
}