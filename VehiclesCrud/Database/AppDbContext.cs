using Microsoft.EntityFrameworkCore;
using VehiclesCrud.Domain;

namespace VehiclesCrud.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<Vehicle> Vehicles { get; set; }
        
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}
