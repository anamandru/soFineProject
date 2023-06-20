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
    public class SpecialistAccountsController : Controller
    {
        private SoFineDB db = new SoFineDB();

        // GET: SpecialistAccounts
        public ActionResult Index()
        {
            return View(db.SpecialistAccounts.ToList());
        }

        // GET: SpecialistAccounts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SpecialistAccount specialistAccount = db.SpecialistAccounts.Find(id);
            if (specialistAccount == null)
            {
                return HttpNotFound();
            }
            return View(specialistAccount);
        }

        // GET: SpecialistAccounts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SpecialistAccounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Email,Password,CliniqueName,University,DiplomaNumber,Validation")] SpecialistAccount specialistAccount)
        {
            if (ModelState.IsValid)
            {
                specialistAccount.Validation = false;
                db.SpecialistAccounts.Add(specialistAccount);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(specialistAccount);
        }

        // GET: SpecialistAccounts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SpecialistAccount specialistAccount = db.SpecialistAccounts.Find(id);
            if (specialistAccount == null)
            {
                return HttpNotFound();
            }
            return View(specialistAccount);
        }

        // POST: SpecialistAccounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Email,Password,CliniqueName,University,DiplomaNumber,Validation")] SpecialistAccount specialistAccount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(specialistAccount).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(specialistAccount);
        }

        // GET: SpecialistAccounts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SpecialistAccount specialistAccount = db.SpecialistAccounts.Find(id);
            if (specialistAccount == null)
            {
                return HttpNotFound();
            }
            return View(specialistAccount);
        }

        // POST: SpecialistAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SpecialistAccount specialistAccount = db.SpecialistAccounts.Find(id);
            db.SpecialistAccounts.Remove(specialistAccount);
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
