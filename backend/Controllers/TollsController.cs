using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoadTollAPI.Context;
using RoadTollAPI.DTOs;
using RoadTollAPI.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RoadTollAPI.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("CORSPolicy")]
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
        public ActionResult<IEnumerable<TollDTO>> GetAllByMonth(int month)
        {
            if (month < 1 || month > 12) return new NotFoundObjectResult(new { message = "Month out of range" });

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

            if (car != null)
            {
                foreach (var toll in car.tolls)
                    if (toll.date.Month == month)
                        tolls.Add(new TollDTO { date = toll.date, rate = 0 });
            }

            return tolls;
        }

        // GET api/<TollsController>/5
        [HttpGet("{id}")]
        public Toll Get(int id)
        {
            return _context.Tolls.Where(t => t.id == id).FirstOrDefault();
        }

        // POST api/<TollsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
            var car = _context.Cars.Where(c => c.id == 1);
        }

        // PUT api/<TollsController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Toll value)
        {
            var toll = _context.Tolls.Find(id);

            if (toll != null)
            {
                try
                {
                    toll.date = value.date;
                    _context.SaveChanges();
                } catch(Exception e)
                {
                    return new NotFoundObjectResult(new { success= false, message = "Error while updating!", errorMessage = e.Message });
                }

                return new OkObjectResult(new { success = true, message = "Toll updated" });
                
            } else
            {
                return new NotFoundObjectResult(new { success = false, message = "Toll not found with id", id = id });
            }
        }

        // DELETE api/<TollsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
