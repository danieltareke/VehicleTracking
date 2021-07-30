using Microsoft.EntityFrameworkCore;
using Registration.Core.Domain;
using Registration.Infrastructure.Data.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Infrastructure.Data
{
    public class RegistrationDbContext: DbContext
    {
        public RegistrationDbContext(DbContextOptions<RegistrationDbContext> options) : base(options) { }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.HasDefaultSchema("vts"); //vehicle tracking system

            modelBuilder.ApplyConfiguration(new DeviceRegistrationConfiguration());
        }

        public DbSet<DeviceRegistration> DeviceRegistrations { get; set; }
    }
}
