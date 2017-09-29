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
        private ApplicationDbContext _context;

        public CarController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Car
        public ActionResult Index()
        {
            var cars = _context.Cars.ToList();

            return View(cars);
        }

        // GET: Car/Create
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Save(Car car)
        {
            if (car.Id == 0)
            {
                _context.Cars.Add(car);
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}