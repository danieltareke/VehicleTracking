using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Registration.Core.Domain;
using Registration.Core.Interfaces.Repository;
using Registration.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Infrastructure.Repository
{
    public class DeviceRegistrationRepository : GenericRepository<DeviceRegistration>, IDeviceRegistrationRepository
    {
        public DeviceRegistrationRepository(
            RegistrationDbContext context,
            ILogger logger
        ) : base(context, logger)
        {

        }

        public override async Task<IEnumerable<DeviceRegistration>> All()
        {
            try
            {
                return await dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All method error", typeof(DeviceRegistrationRepository));
                return new List<DeviceRegistration>();
            }
        }

        public override async Task<bool> Upsert(DeviceRegistration entity)
        {
            try
            {
                var device = await dbSet.Where(x => x.DeviceId == entity.DeviceId)
                                                        .FirstOrDefaultAsync();

                if (device == null)
                    return await Add(entity);

                device.DeviceId = entity.DeviceId;
                device.RegistrationTime = entity.RegistrationTime;

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Upsert method error", typeof(DeviceRegistrationRepository));
                return false;
            }
        }

        public async Task<DeviceRegistration> GetByDeviceId(string id)
        {
            var device = await dbSet.Where(x => x.DeviceId == id)
                                                       .FirstOrDefaultAsync();
            return device;
        }
    }
}
