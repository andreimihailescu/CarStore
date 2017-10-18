using CarStore.Models;
using CarStore.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            var cars = _context.Cars
                .Include(c => c.CarType)
                .Include(c => c.Showroom)
                .ToList();

            if (User.IsInRole("CanManageCars"))
            {
                return View("Index", cars);

            }

            return View("IndexRestricted", cars);
        }

        // GET: Car/Create
        [Authorize(Roles = "CanManageCars")]
        public ActionResult Create()
        {
            var carTypes = _context.CarTypes.ToList();

            var viewModel = new CarsFormViewModel()
            {
                Car = new Car(),
                CarType = carTypes
            };

            return View("CarForm", viewModel);
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
            var carTypes = _context.CarTypes.ToList();

            var viewModel = new CarsFormViewModel()
            {
                Car = car,
                CarType = carTypes
            };

            return View("CarForm", viewModel);
        }

        // GET: Car/Save
        [HttpPost]
        [Authorize(Roles = "CanManageCars")]
        public ActionResult Save(Car car)
        {
            if (!ModelState.IsValid)
            {
                var carTypes = _context.CarTypes.ToList();

                var viewModel = new CarsFormViewModel()
                {
                    Car = new Car(),
                    CarType = carTypes
                };

                return View("CarForm", viewModel);
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
                carInDb.CarTypeId = car.CarTypeId;
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