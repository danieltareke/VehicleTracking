using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Registration.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Infrastructure.Data.Config
{
    public class DeviceRegistrationConfiguration:IEntityTypeConfiguration<DeviceRegistration>
    {
        public void Configure(EntityTypeBuilder<DeviceRegistration> builder)
        {
            builder.ToTable("device_registration")
                .HasKey(k => k.DeviceId);

            builder.Property(p => p.DeviceId)
                .HasColumnName("device_id")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(p => p.RegistrationTime)
                .HasColumnName("registration_time");
        }
    }
}
