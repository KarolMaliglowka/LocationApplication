using System;
using System.Collections.Generic;
using System.Text;
using LA.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LA.Infrastructure.Data.Configuration
{
    public class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.ToTable(nameof(Location));
            builder.HasKey(location => location.Id);

            builder.Property(x => x.PositionX);
            builder.Property(x => x.PositionY);
            builder.Property(x => x.PositionZ);
            builder.Property(x => x.BatteryChargeStatus);
            builder.Property(x => x.IsCharging);
            builder.Property(x => x.CreatedAt);
            builder.Property(x => x.UpdatedAt);
        }
    }
}