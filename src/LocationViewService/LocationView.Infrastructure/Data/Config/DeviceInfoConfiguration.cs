using LocationView.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocationView.Infrastructure.Data.Config
{
    public class DeviceInfoConfiguration : IEntityTypeConfiguration<DeviceInfo>
    {
        public void Configure(EntityTypeBuilder<DeviceInfo> builder)
        {
            builder.ToTable("device_info")
                .HasKey(k => k.DeviceId);

            builder.Property(p => p.DeviceId)
                .HasColumnName("device_id")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(p => p.RegistrationTime)
                .HasColumnName("registration_time");

            builder.Property(p => p.VehiclePlateNo)
                .HasMaxLength(30)
                .HasColumnName("plate_no");
        }
    }
}
