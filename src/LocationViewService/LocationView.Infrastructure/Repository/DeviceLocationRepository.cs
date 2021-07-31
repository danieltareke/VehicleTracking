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

        public override async Task<IEnumerable<DeviceLocation>> All()
        {
            try
            {
                return await dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All method error", typeof(DeviceLocationRepository));
                return new List<DeviceLocation>();
            }
        }

        public override async Task<bool> Upsert(DeviceLocation entity)
        {
            try
            {
                var device = await dbSet.Where(x => x.DeviceLocationId == entity.DeviceLocationId)
                                                        .FirstOrDefaultAsync();

                if (device == null)
                    return await Add(entity);

                device.DeviceId = entity.DeviceId;
                device.TimeStamp = entity.TimeStamp;
                device.Latitude = entity.Latitude;
                device.Longitude = entity.Longitude;

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Upsert method error", typeof(DeviceLocationRepository));
                return false;
            }
        }

        
    }
}
