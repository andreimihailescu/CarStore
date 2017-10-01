using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarStore.Controllers
{
    public class CatsController : Controller
    {
        // GET: Cats
        public ActionResult Index()
        {
            return View();
        }
    }
}