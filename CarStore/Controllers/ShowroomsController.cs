using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarStore.Models;
using System.Data.SqlClient;
using CarStore.Models.ViewModel;

namespace CarStore.Controllers
{
    public class ShowroomsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Showrooms
        public ActionResult Index()
        {
            return View(db.Showrooms.ToList());
        }

        // GET: Showrooms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Showroom showroom = db.Showrooms.Find(id);
            if (showroom == null)
            {
                return HttpNotFound();
            }
            return View(showroom);
        }

        // GET: Showrooms/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Showrooms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Address,Limit")] Showroom showroom)
        {
            if (ModelState.IsValid)
            {
                db.Showrooms.Add(showroom);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(showroom);
        }

        // GET: Showrooms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Showroom showroom = db.Showrooms.Find(id);
            if (showroom == null)
            {
                return HttpNotFound();
            }
            return View(showroom);
        }

        // POST: Showrooms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Address,Limit")] Showroom showroom)
        {
            if (ModelState.IsValid)
            {
                db.Entry(showroom).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(showroom);
        }

        // GET: Showrooms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Showroom showroom = db.Showrooms.Find(id);
            if (showroom == null)
            {
                return HttpNotFound();
            }
            return View(showroom);
        }

        // POST: Showrooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Showroom showroom = db.Showrooms.Find(id);
            db.Showrooms.Remove(showroom);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Showrooms/ManageCars/5
        public ActionResult ManageCars(int id)
        {
            //// CALL STORED PROCEDURE
            //using (var conn = new SqlConnection(@"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\aspnet-CarStore-20170928080302.mdf;Initial Catalog=aspnet-CarStore-20170928080302;Integrated Security=True"))
            //using (var command = new SqlCommand("AddCarType", conn)
            //{
            //    CommandType = CommandType.StoredProcedure
            //})
            //{
            //    conn.Open();
            //    command.ExecuteNonQuery();
            //}

            var showroom = db.Showrooms.Find(id);

            var cars = db.Cars.Where(c => c.ShowroomId == id).ToList();

            if (showroom == null)
            {
                return HttpNotFound();
            }

            var viewModel = new ManagerCarsViewModel()
            {
                Showroom = showroom,
                Cars = cars
            };

            return View(viewModel);
        }

        //Mai e de lucrat
        // POST: Showrooms/SaveManageCars
        [HttpPost]
        public ActionResult SaveManageCars(ManagerCarsViewModel viewModel)
        {
            var cars = viewModel.Cars;

            foreach(var car in cars)
            {
                var currentCar = db.Cars.SingleOrDefault(c => c.Id == car.Id);

                if(currentCar == null)
                {
                    return HttpNotFound();
                }

                currentCar.ShowroomId = viewModel.Showroom.Id;
            }

            db.SaveChanges();

            //return View("Index");
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
