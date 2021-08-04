using Registration.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Core.Interfaces.Repository
{
    public interface IDeviceRegistrationRepository : IGenericRepository<DeviceRegistration>
    {
        Task<DeviceRegistration> GetByDeviceId(string id);
    }
}
