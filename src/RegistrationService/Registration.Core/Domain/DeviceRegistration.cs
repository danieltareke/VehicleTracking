using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Core.Domain
{
    public class DeviceRegistration
    {
        
        //ID that comes from the device
        [Required]
        public string DeviceId { get; set; }
        //auto capture date by system
        public DateTime RegistrationTime { get; set; }
    }
}
