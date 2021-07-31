using LocationView.Core.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationView.Core.Interfaces
{
    public interface IUnitOfWork
    {
        IDeviceInfoRepository Devices { get; }
        IDeviceLocationRepository Locations { get; }

        Task CompleteAsync();
    }
}
