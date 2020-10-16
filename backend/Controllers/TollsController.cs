using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoadTollAPI.Context;
using RoadTollAPI.DTOs;
using RoadTollAPI.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RoadTollAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TollsController : ControllerBase
    {
        private readonly RoadTollAPIDBContext _context;

        public TollsController(RoadTollAPIDBContext context)
        {
            _context = context;
        }

        // GET: api/<TollsController>
        [HttpGet]
        public IEnumerable<Toll> Get()
        {
            return _context.Tolls.ToArray();
        }

        [HttpGet]
        [Route("[action]/{month}")]
        public IEnumerable<TollDTO> GetAllByMonth(int month)
        {
            var tolls = new List<TollDTO>();

            foreach( var toll in _context.Tolls.Include(t => t.car).ToArray())
                if (toll.date.Month == month)
                    tolls.Add(new TollDTO { date = toll.date, regnr = toll.car.regnr, rate = 0 });
  
            return tolls;
        }

        [Route("[action]/{month}/{regnr}")]
        public IEnumerable<TollDTO> GetAllByMonthCar(int month, string regnr)
        {
            var tolls = new List<TollDTO>();
            var car = _context.Cars.Where(c => c.regnr == regnr).Include(c => c.tolls).FirstOrDefault();

            foreach (var toll in car.tolls )
                if (toll.date.Month == month)
                    tolls.Add(new TollDTO { date = toll.date, rate = 0 });

            return tolls;
        }

        // GET api/<TollsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TollsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TollsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TollsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
