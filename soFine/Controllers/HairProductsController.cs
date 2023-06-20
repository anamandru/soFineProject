using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using soFine;
using soFine.Enums;
using soFine.Models;

namespace soFine.Controllers
{
    public class HairProductsController : Controller
    {
        private SoFineDB db = new SoFineDB();

        // GET: HairProducts
        public ActionResult Index()
        {
            return View(db.HairProducts.ToList());
        }

        // GET: HairProducts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HairProduct hairProduct = db.HairProducts.Find(id);
            if (hairProduct == null)
            {
                return HttpNotFound();
            }
            return View(hairProduct);
        }

        // GET: HairProducts/Create
        public ActionResult Create()
        {
            Hair hairTypes = new Hair();
            List<string> hairTypesList = hairTypes.hairTypes;
            ViewBag.HairTypes = hairTypesList;

            HairProductCategories categories = new HairProductCategories();
            List<string> categoriesList = categories.Hairproductcategories;
            ViewBag.Hairproductcategories = categoriesList;

            return View();
        }

        // POST: HairProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,ProductName,Description,HairType,Category,ImageUrl,ImageData")] HairProduct hairProduct)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var imageData = await client.GetByteArrayAsync(hairProduct.ImageUrl);
                    hairProduct.ImageData = imageData;

                    // Save the model to the database
                    // Your code to save the model to the database goes here
                    // Example: dbContext.Images.Add(model);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Failed to download the image: {ex.Message}");
                    return View();
                }
            }
            if (ModelState.IsValid)
            {
                db.HairProducts.Add(hairProduct);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hairProduct);
        }

        // GET: HairProducts/Edit/5
        public ActionResult Edit(int? id)
        {
            HairProduct hairProduct = db.HairProducts.Find(id);
            List<string> h = new List<string>();
            List<string> c = new List<string>();

            h.Add(hairProduct.HairType);
            ViewBag.HairType = h;

            c.Add(hairProduct.Category);
            ViewBag.Hairproductcategories = c;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (hairProduct == null)
            {
                return HttpNotFound();
            }
            return View(hairProduct);
        }

        // POST: HairProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,ProductName,Description,HairType,Category,ImageUrl,ImageData")] HairProduct hairProduct)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var imageData = await client.GetByteArrayAsync(hairProduct.ImageUrl);
                    hairProduct.ImageData = imageData;

                    // Save the model to the database
                    // Your code to save the model to the database goes here
                    // Example: dbContext.Images.Add(model);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Failed to download the image: {ex.Message}");
                    return View();
                }
            }
            if (ModelState.IsValid)
            {
                db.Entry(hairProduct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hairProduct);
        }

        // GET: HairProducts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HairProduct hairProduct = db.HairProducts.Find(id);
            if (hairProduct == null)
            {
                return HttpNotFound();
            }
            return View(hairProduct);
        }

        // POST: HairProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HairProduct hairProduct = db.HairProducts.Find(id);
            db.HairProducts.Remove(hairProduct);
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
