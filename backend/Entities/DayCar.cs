using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoadTollAPI.Entities
{
    public class DayCar
    {
        public int carId { get; set; }
        public Car car { get; set; }

        public int dayId { get; set; }
        public Day day { get; set; }
    }
}
