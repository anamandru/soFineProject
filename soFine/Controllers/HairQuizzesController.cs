using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using soFine;
using soFine.Models;

namespace soFine.Controllers
{
    public class HairQuizzesController : Controller
    {
        private SoFineDB db = new SoFineDB();

        // GET: HairQuizzes
        public ActionResult Index()
        {
            return View(db.HairQuizs.ToList());
        }

        // GET: HairQuizzes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HairQuiz hairQuiz = db.HairQuizs.Find(id);
            if (hairQuiz == null)
            {
                return HttpNotFound();
            }
            return View(hairQuiz);
        }

        // GET: HairQuizzes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HairQuizzes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Question,Answer")] HairQuiz hairQuiz)
        {
            if (ModelState.IsValid)
            {
                db.HairQuizs.Add(hairQuiz);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hairQuiz);
        }

        // GET: HairQuizzes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HairQuiz hairQuiz = db.HairQuizs.Find(id);
            if (hairQuiz == null)
            {
                return HttpNotFound();
            }
            return View(hairQuiz);
        }

        // POST: HairQuizzes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Question,Answer")] HairQuiz hairQuiz)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hairQuiz).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hairQuiz);
        }

        // GET: HairQuizzes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HairQuiz hairQuiz = db.HairQuizs.Find(id);
            if (hairQuiz == null)
            {
                return HttpNotFound();
            }
            return View(hairQuiz);
        }

        // POST: HairQuizzes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HairQuiz hairQuiz = db.HairQuizs.Find(id);
            db.HairQuizs.Remove(hairQuiz);
            db.SaveChanges();
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
