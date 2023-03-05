using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Destination
    {
        public Destination() { 
            this.Comments=new HashSet<Comment>();
        }    
        [Key]
        public int DestinationId { get; set; }
        public string City { get; set; }
        public string DayNight { get; set; }
        public double price { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public string Capacity { get; set; }
        public string CoverImageUrl { get; set; }
        public string SecondImageUrl { get; set; }
        public bool status { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public List<Reservation> Reservations { get; set; }
      

    }
}
