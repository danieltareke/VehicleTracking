using Registration.Core.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Core.Interfaces
{
    public interface IUnitOfWork
    {
        IDeviceRegistrationRepository Devices { get; }

        Task CompleteAsync();
    }
}
