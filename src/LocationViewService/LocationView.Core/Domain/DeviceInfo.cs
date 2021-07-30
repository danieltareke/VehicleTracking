using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationView.Core.Domain
{
    public class DeviceInfo
    {
        public string DeviceId { get; set; }
        public DateTime VehiclePlateNo { get; set; }
        public DateTime RegistrationTime { get; set; }
        public List<DeviceLocation> Locations { get; set; }
    }
}
