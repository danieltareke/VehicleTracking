using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Core.Domain
{
    public class DeviceRegistration
    {
        
        //ID that comes from the device
        public string DeviceId { get; set; }
        //auto capture date by system
        public DateTime RegistrationTime { get; set; }
    }
}
