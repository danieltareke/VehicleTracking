using LocationView.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocationView.Infrastructure.Data.Config
{
    public class DeviceLocationConfiguration : IEntityTypeConfiguration<DeviceLocation>
    {
        public void Configure(EntityTypeBuilder<DeviceLocation> builder)
        {
            builder.ToTable("device_location")
                .HasKey(k => k.DeviceLocationId);

            builder.Property(p => p.TimeStamp)
                .HasColumnName("time_stamp");

            builder.Property(p => p.Latitude)
                .HasColumnName("latitude")
                 .HasMaxLength(20);

            builder.Property(p => p.Longitude)
                .HasColumnName("longitude")
                .HasMaxLength(20);

            builder.HasOne(d=>d.Device)
                .WithMany(l=>l.Locations)
                .HasForeignKey(d=>d.DeviceId);
        }
    }
}
