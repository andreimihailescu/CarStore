using CarStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarStore.Controllers.Api
{
    public class CarsController : ApiController
    {
        private ApplicationDbContext _context;

        public CarsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: /api/cars
        public IHttpActionResult GetCars()
        {
            return Ok(_context.Cars.ToList());
        }

        // GET: /api/cars/id
        public IHttpActionResult GetCar(int id)
        {
            var car = _context.Cars.SingleOrDefault(c => c.Id == id);

            if(car == null)
            {
                return NotFound();
                //return Redirect("http://localhost:53190/api/cats");
            }

            return Ok(car);
        }

        // GET: /api/cars?brand=BMW&model=X6
        public IHttpActionResult GetCar(string model, string brand)
        {
            var car = _context.Cars.SingleOrDefault(c => c.Model == model && c.Brand == brand);

            if (car == null)
            {
                return NotFound();
                //return Redirect("http://localhost:53190/api/cats");
            }

            return Ok(car);
        }
    }
}
