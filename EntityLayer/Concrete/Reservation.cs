using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public string PersonCount { get; set; }
        public int DestinationId { get; set; }
        public Destination Destination { get; set; }
        public DateTime StartDate { get; set; }
        public string Details { get; set; }
        public bool Status { get; set; }

    }
}
