using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class About2
    {
        [Key]
        public int About2Id { get; set; }
        public string Title { get; set; }
        public string SecondTitle { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
