using LA.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LA.Infrastructure.Data.Configuration
{
    class DeviceConfiguration : IEntityTypeConfiguration<Device>
    {
        public void Configure(EntityTypeBuilder<Device> builder)
        {
            builder.HasKey(x => x.Id);
           // builder.Entity<Device>().HasOne(x => x.)
            //builder.HasMany(x => x.Comments).WithOne().OnDelete(DeleteBehavior.Cascade);
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Device>()
        //        .HasOne(a => a.deviceStatus
        //        );//
        //        //.WithOne(b => b.deviceId)
        //        //.HasForeignKey<AuthorBiography>(b => b.AuthorRef);
        //}
    }
}
