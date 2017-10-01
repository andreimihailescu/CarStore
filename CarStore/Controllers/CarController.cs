﻿using CarStore.Models;
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
            return View("CarForm");
        }

        // GET: Car/Details/id
        public ActionResult Details(int id)
        {
            var car = _context.Cars.SingleOrDefault(c => c.Id == id);

            return View("Details", car);
        }

        // GET: Car/Edit/id
        public ActionResult Edit(int id)
        {
            var car = _context.Cars.SingleOrDefault(c => c.Id == id);

            return View("CarForm", car);
        }

        // GET: Car/Save
        public ActionResult Save(Car car)
        {
            if (car.Id == 0)
            {
                _context.Cars.Add(car);
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // GEt: Car/Delete/id
        public ActionResult Delete(int id)
        {
            var car = _context.Cars.SingleOrDefault(c => c.Id == id);

            _context.Cars.Remove(car);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}