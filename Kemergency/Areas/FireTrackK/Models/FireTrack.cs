using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kemergency.Areas.FireTrackK.Models
{
    public class FireTrack
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string TrackNumber { get; set; }
        public string phoneNumber { get; set; }
        public string DriverName { get; set; }
        public string DriverNumber { get; set; }

    }
}
