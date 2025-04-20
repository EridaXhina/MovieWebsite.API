using Microsoft.EntityFrameworkCore;
using MovieSearchAPI.Models;

namespace MovieSearchAPI.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Movie> Movies { get; set; }

        internal async Task Where(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }
    }
}
