using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace soFine.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Clients()
        {
            return View("Index");
        }

        public ActionResult Specialists()
        {
            return View("Index");
        }

        public ActionResult HairProducts()
        {
            return View("Index");
        }

        public ActionResult SkinProducts()
        {
            return View("Index");
        }

        public ActionResult Home()
        {
            return View();
        }
    }
}