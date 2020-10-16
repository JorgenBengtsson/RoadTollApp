using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RoadTollAPI.Entities
{
    public class Owner
    {
        [Key]
        public int id { set; get; }
        public string name { get; set; }
        public int age { get; set; }
        public string adress { get; set; }

        public virtual Car car { get; set; }
    }
}
