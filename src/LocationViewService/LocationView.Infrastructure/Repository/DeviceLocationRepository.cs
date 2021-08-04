using LocationView.Core.Domain;
using LocationView.Core.Interfaces.Repository;
using LocationView.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationView.Infrastructure.Repository
{
    public class DeviceLocationRepository : GenericRepository<DeviceLocation>, IDeviceLocationRepository
    {
        public DeviceLocationRepository(
            LocationViewDbContext context,
            ILogger logger
        ) : base(context, logger)
        {

        }

        
        public async Task<DeviceLocation> GetDeviceCurrentLocation(string id)
        {
            var currentLocation = await dbSet.Where(x => x.DeviceId == id)
                                    .OrderByDescending(x=>x.DeviceLocationId)
                                    .FirstOrDefaultAsync();
            return currentLocation;
        }

        public async Task<List<DeviceLocation>> GetDeviceLocationOverCertainTime(string id, DateTime from, DateTime to)
        {
            var locationRange = await dbSet.Where(x => x.DeviceId == id)
                                    .Where(x => x.TimeStamp >= from)
                                     .Where(x => x.TimeStamp <= to)
                                    .ToListAsync();
            return locationRange;
        }
    }
}
