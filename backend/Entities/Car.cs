using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RoadTollAPI.Entities
{
    public class Car
    {
        [ForeignKey("Owner")]
        public int id { get; set; }
        public string regnr { get; set; }

        public int CarOfOwnerId { get; set; }
        public virtual Owner owner { get; set; }

        public IList<DayCar> daycars { get; set; }

        public IList<Toll> tolls { get; set; }
    }
}
