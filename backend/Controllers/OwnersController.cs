using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoadTollAPI.Context;
using RoadTollAPI.Entities;
using RoadTollAPI.ActionResults;
using Microsoft.AspNetCore.Identity;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RoadTollAPI.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("CORSPolicy")]
    [ApiController]
    public class OwnersController : ControllerBase
    {
        private readonly RoadTollAPIDBContext _context;

        public OwnersController(RoadTollAPIDBContext context)
        {
            _context = context;
        }

        // GET: api/<OwnersController>
        [HttpGet]
        public IEnumerable<Owner> Get()
        {
            return _context.Owners.Include(o => o.car).ToArray<Owner>();
        }

        // GET api/<OwnersController>/5
        [HttpGet("{id}")]
        public Owner Get(int id)
        {
            var owner = _context.Owners.Where(o => o.id == id).FirstOrDefault();
            if (owner != null)
                return owner;
            else
                return null;
        }

        // POST api/<OwnersController>
        [HttpPost]
        public void Post([FromBody] Owner owner) {
            _context.Owners.Add(owner);
            _context.SaveChanges();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Owner owner)
        {
            var o = _context.Owners.SingleOrDefault(o => o.id == id);

            if (o != null)
            {
                o.name = owner.name;
                o.age = owner.age;
                o.adress = owner.adress;

                try
                {
                    _context.SaveChanges();
                }
                catch (Exception e)
                {
                    return new BadRequestObjectResult(new { status = "Error", message = "Unable to make update to id: " + id, errorMessage = e.Message });
                }
                return Ok(new { message = "Object with id: " + id + " was updated correctly" });
            }
            else
            {
                return StatusCode(404); // new NotFoundResult();
            }
        }

        // DELETE api/<OwnersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var owner = new Owner { id = id };
            _context.Owners.Attach(owner);
            _context.Owners.Remove(owner);
            _context.SaveChanges();
        }
    }
}
