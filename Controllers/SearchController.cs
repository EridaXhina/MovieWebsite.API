using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieSearchAPI.Data;
using MovieSearchAPI.Models;

namespace MovieSearchAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SearchController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SearchController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return Ok(new List<Movie>());

            var results = await _context.Movies
                .Where(m => m.Title.ToLower().Contains(query.ToLower()) ||
                m.Description.ToLower().Contains(query.ToLower()) ||
                m.Genre.ToLower().Contains(query.ToLower()))
                .ToListAsync();



            return Ok(results);
        }
    }
}

