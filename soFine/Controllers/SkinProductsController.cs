using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using soFine;
using soFine.Enums;
using soFine.Models;
using System.Threading.Tasks;

namespace soFine.Controllers
{
    public class SkinProductsController : Controller
    {
        private SoFineDB db = new SoFineDB();

        // GET: SkinProducts
        public ActionResult Index()
        {
            return View(db.SkinProducts.ToList());
        }

        // GET: SkinProducts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SkinProduct skinProduct = db.SkinProducts.Find(id);
            if (skinProduct == null)
            {
                return HttpNotFound();
            }
            return View(skinProduct);
        }

        // GET: SkinProducts/Create
        public ActionResult Create()
        {
            Skin skinTypes = new Skin();
            List<string> skinTypesList = skinTypes.skinTypes;
            ViewBag.SkinTypes = skinTypesList;

            SkinProductCategories categories = new SkinProductCategories();
            List<string> categoriesList = categories.skinproductcategories;
            ViewBag.skinproductcategories = categoriesList;
            return View();
        }

        // POST: SkinProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,ProductName,Description,SkinType,Category,ImageUrl,ImageData")] SkinProduct skinProduct)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var imageData = await client.GetByteArrayAsync(skinProduct.ImageUrl);
                    skinProduct.ImageData = imageData;

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
                db.SkinProducts.Add(skinProduct);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(skinProduct);
        }

        // GET: SkinProducts/Edit/5
        public ActionResult Edit(int? id)
         {
             SkinProduct skinProduct = db.SkinProducts.Find(id);
             List<string> s = new List<string>();
             List<string> c = new List<string>();

             s.Add(skinProduct.SkinType);
             ViewBag.SkinTypes = s;

             c.Add(skinProduct.Category);
             ViewBag.skinproductcategories = c;


             if (id == null)
             {
                 return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
             }

             if (skinProduct == null)
             {
                 return HttpNotFound();
             }
             return View(skinProduct);
         }

        // POST: SkinProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,ProductName,Description,SkinType,Category,ImageUrl,ImageData")] SkinProduct skinProduct)
        {

            using (var client = new HttpClient())
            {
                try
                {
                    var imageData = await client.GetByteArrayAsync(skinProduct.ImageUrl);
                    skinProduct.ImageData = imageData;

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
                db.Entry(skinProduct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(skinProduct);
        }

        // GET: SkinProducts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SkinProduct skinProduct = db.SkinProducts.Find(id);
            if (skinProduct == null)
            {
                return HttpNotFound();
            }
            return View(skinProduct);
        }

        // POST: SkinProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SkinProduct skinProduct = db.SkinProducts.Find(id);
            db.SkinProducts.Remove(skinProduct);
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
