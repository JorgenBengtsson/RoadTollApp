using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RoadTollAPI.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        public string Index()
        {
            return "Welcome to the Road Toll API!";
        }
    }
}
