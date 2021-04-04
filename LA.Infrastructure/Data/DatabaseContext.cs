using LA.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace LA.Infrastructure.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) {}

        public DbSet<Device> Devices { get; set; }
        public DbSet<Location> Localizations { get; set; }
    }
}