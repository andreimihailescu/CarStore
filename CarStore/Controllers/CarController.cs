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
        [Authorize(Roles = "CanManageCars")]
        public ActionResult Create()
        {
            return View("CarForm");
        }

        // GET: Car/Details/id
        public ActionResult Details(int id)
        {
            var car = _context.Cars.SingleOrDefault(c => c.Id == id);

            return View("Details", car);
        }

        // GET: Car/Edit/id
        [Authorize(Roles = "CanManageCars")]
        public ActionResult Edit(int id)
        {
            var car = _context.Cars.SingleOrDefault(c => c.Id == id);

            return View("CarForm", car);
        }

        // GET: Car/Save
        [HttpPost]
        [Authorize(Roles = "CanManageCars")]
        public ActionResult Save(Car car)
        {
            if (!ModelState.IsValid)
            {
                return View("CarForm", car);
            }
                var carInDb = _context.Cars.SingleOrDefault(c => c.Id == car.Id);

            if (carInDb == null)
            {
                _context.Cars.Add(car);
            }
            else
            {
                carInDb.SerialNumber = car.SerialNumber;
                carInDb.Brand = car.Brand;
                carInDb.Model = car.Model;
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: Car/Delete/id
        [Authorize(Roles = "CanManageCars")]
        public ActionResult Delete(int id)
        {
            var car = _context.Cars.SingleOrDefault(c => c.Id == id);

            _context.Cars.Remove(car);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}