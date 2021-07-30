using Microsoft.EntityFrameworkCore;
using LocationView.Core.Domain;
using LocationView.Infrastructure.Data.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationView.Infrastructure.Data
{
    public class LocationViewDbContext: DbContext
    {
        public LocationViewDbContext(DbContextOptions<LocationViewDbContext> options) : base(options) { }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.HasDefaultSchema("vts"); //vehicle tracking system

            modelBuilder.ApplyConfiguration(new DeviceInfoConfiguration());
            modelBuilder.ApplyConfiguration(new DeviceLocationConfiguration());
        }

        public DbSet<DeviceLocation> DeviceLocationViews { get; set; }
    }
}
