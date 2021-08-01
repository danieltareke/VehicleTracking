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
    public class DeviceInfoRepository : GenericRepository<DeviceInfo>, IDeviceInfoRepository
    {
        public DeviceInfoRepository(
            LocationViewDbContext context,
            ILogger logger
        ) : base(context, logger)
        {

        }

        public override async Task<IEnumerable<DeviceInfo>> All()
        {
            try
            {
                return await dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All method error", typeof(DeviceInfoRepository));
                return new List<DeviceInfo>();
            }
        }

        public async Task<DeviceInfo> GetByDeviceId(string id)
        {
            var device = await dbSet.Where(x => x.DeviceId ==id)
                                                       .FirstOrDefaultAsync();

            return device;
        }

        public override async Task<bool> Upsert(DeviceInfo entity)
        {
            try
            {
                var device = await dbSet.Where(x => x.DeviceId == entity.DeviceId)
                                                        .FirstOrDefaultAsync();

                if (device == null)
                    return await Add(entity);

                device.DeviceId = entity.DeviceId;
                device.VehiclePlateNo = entity.VehiclePlateNo;
                device.RegistrationTime = entity.RegistrationTime;

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Upsert method error", typeof(DeviceInfoRepository));
                return false;
            }
        }

        
    }
}
