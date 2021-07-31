using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationUpdate.Core.Domain
{
    public class LocationInfo
    {
        public string DeviceId { get; set; }
        public DateTime TimeStamp { get; set; }//time the data was captured
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        
    }
}
