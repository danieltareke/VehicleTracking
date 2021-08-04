using System;
using System.ComponentModel.DataAnnotations;

namespace MessageModel
{
    public class Location
    {
        [Required]
        public string DeviceId { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

    }
}
