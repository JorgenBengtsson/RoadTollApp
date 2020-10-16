using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoadTollAPI.Entities
{
    public class Day
    {
        public int id { get; set; }
        public DateTime day { get; set; }

        public IList<DayCar> daycars { get; set; }
    }
}
