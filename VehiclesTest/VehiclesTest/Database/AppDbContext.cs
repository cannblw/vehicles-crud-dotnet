using Microsoft.EntityFrameworkCore;
using VehiclesTest.Models;

namespace VehiclesTest.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<Vehicle> Vehicles { get; set; }
        
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}
