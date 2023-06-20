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
    public class SkinQuizzesController : Controller
    {
        private SoFineDB db = new SoFineDB();

        // GET: SkinQuizzes
        public ActionResult Index()
        {
            return View(db.SkinQuizs.ToList());
        }

        // GET: SkinQuizzes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SkinQuiz skinQuiz = db.SkinQuizs.Find(id);
            if (skinQuiz == null)
            {
                return HttpNotFound();
            }
            return View(skinQuiz);
        }

        // GET: SkinQuizzes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SkinQuizzes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Question,Answer")] SkinQuiz skinQuiz)
        {
            if (ModelState.IsValid)
            {
                db.SkinQuizs.Add(skinQuiz);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(skinQuiz);
        }

        // GET: SkinQuizzes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SkinQuiz skinQuiz = db.SkinQuizs.Find(id);
            if (skinQuiz == null)
            {
                return HttpNotFound();
            }
            return View(skinQuiz);
        }

        // POST: SkinQuizzes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Question,Answer")] SkinQuiz skinQuiz)
        {
            if (ModelState.IsValid)
            {
                db.Entry(skinQuiz).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(skinQuiz);
        }

        // GET: SkinQuizzes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SkinQuiz skinQuiz = db.SkinQuizs.Find(id);
            if (skinQuiz == null)
            {
                return HttpNotFound();
            }
            return View(skinQuiz);
        }

        // POST: SkinQuizzes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SkinQuiz skinQuiz = db.SkinQuizs.Find(id);
            db.SkinQuizs.Remove(skinQuiz);
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
