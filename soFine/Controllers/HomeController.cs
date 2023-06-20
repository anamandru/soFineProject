using soFine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace soFine.Controllers
{
    public class HomeController : Controller
    {
        private SoFineDB db = new SoFineDB();

        public ActionResult Index()
        {
            List<Article> articles = new List<Article>();

            foreach(Article article in db.Articles)
            {
                articles.Add(article);
            }

            return View(articles);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Article(int id)
        {
            Article article = db.Articles.Find(id);
            return View(article);
        }
    }
}