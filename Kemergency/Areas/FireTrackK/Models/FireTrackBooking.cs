using Kemergency.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kemergency.Areas.FireTrackK.Models
{
    public class FireTrackBooking
    {
        public int Id { get; set; }
        public Myusers Myuser { get; set; }
        public string MyuserId { get; set; }
        public int  FireTrackId { get; set; }
        public FireTrack FireTrack { get; set; }
        public DateTime BookingTime { get; set; }
        public bool IsbookingConfirmed { get; set; }
    }
}
