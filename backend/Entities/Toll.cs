using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoadTollAPI.Entities
{
    public class Toll
    {
        public int id { get; set; }

        public DateTime date { get; set; }

        public int currentCarId { get; set; }
        public Car car { get; set; }
    }
}
