using LA.Core.Models;
using LA.Infrastructure.Data.Configuration;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Text;

namespace LA.Infrastructure.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<Device> Devices { get; set; }
        public DbSet<DeviceStatus> DeviceStatuses { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new DeviceConfiguration());

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }



    }
}
