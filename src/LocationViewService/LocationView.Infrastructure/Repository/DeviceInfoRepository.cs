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

 
        public async Task<DeviceInfo> GetByDeviceId(string id)
        {
            var device = await dbSet.Where(x => x.DeviceId ==id)
                                                       .FirstOrDefaultAsync();            
            return device;
        }

       

        
    }
}
