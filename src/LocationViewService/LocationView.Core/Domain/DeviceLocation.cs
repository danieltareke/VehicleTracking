using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationView.Core.Domain
{
    public class DeviceLocation
    {
        public int DeviceLocationId { get; set; }
        public DateTime TimeStamp { get; set; }//time the data was captured
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        public string DeviceId { get; set; }
        public virtual DeviceInfo Device { get; set; }
    }
}
