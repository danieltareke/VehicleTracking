using LocationView.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationView.Core.Interfaces.Repository
{
    public interface IDeviceInfoRepository : IGenericRepository<DeviceInfo>
    {
        Task<DeviceInfo> GetByDeviceId(string id);
        
    }
}
