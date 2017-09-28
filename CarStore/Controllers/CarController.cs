using CarStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarStore.Controllers
{
    public class CarController : Controller
    {
        // GET: Car
        public ActionResult Index()
        {
            var car = new Car()
            {
                Id = 1,
                Model = "M3",
                Brand = "BMW",
                SerialNumber = "xc45612"

            };

            return View(car);
        }
    }
}