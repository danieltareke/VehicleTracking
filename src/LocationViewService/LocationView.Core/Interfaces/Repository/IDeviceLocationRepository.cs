using LocationView.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationView.Core.Interfaces.Repository
{
    public interface IDeviceLocationRepository : IGenericRepository<DeviceLocation>
    {
        Task<DeviceLocation> GetDeviceCurrentLocation(string id);
        Task<List<DeviceLocation>> GetDeviceLocationOverCertainTime(string id,DateTime from, DateTime to);

    }
}
