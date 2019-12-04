using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class HotelMainModule
    {
        public HotelDtl hotel { get; set; }
        public List<RateChart> rates { get; set; }
    }
}
