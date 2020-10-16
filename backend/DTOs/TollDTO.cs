using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoadTollAPI.DTOs
{
    public class TollDTO
    {
        public DateTime date { get; set; }

        public String regnr { get; set; }

        public int rate { get; set; }
    }
}
