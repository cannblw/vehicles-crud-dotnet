using Microsoft.EntityFrameworkCore;

namespace VehiclesTest.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}
