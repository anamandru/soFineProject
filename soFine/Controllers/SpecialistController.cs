using soFine.Enums;
using soFine.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace soFine.Controllers
{
    public class SpecialistController : Controller
    {
        private SoFineDB db = new SoFineDB();
        // GET: Specialist
        public ActionResult LoginValidation(int id)
        {
            int specialistId = (int)(Session["SpecialistId"] = id);
            ViewBag.SpecialistId = id;
            return View(specialistId);
        }
        public ActionResult Home(int id)
        {
            int specialistId = (int)(Session["SpecialistId"] = id);
            ViewBag.SpecialistId = id;
            return View(specialistId);
        }
        public ActionResult FirstPage(int id)
        {
            ViewBag.SpecialistId = id; 
            int specialistId = (int)(Session["SpecialistId"] = id);

            List<Article> articles = new List<Article>();

            foreach (Article article in db.Articles)
            {
                articles.Add(article);
            }

            return View(articles);
        }
        public ActionResult About(int id)
        {
            ViewBag.SpecialistId = id;
            int specialistId = (int)(Session["SpecialistId"] = id);
            return View(specialistId);
        }

        public ActionResult EditAccount(int? id)
        {
            ViewBag.SpecialistId = id;
            SpecialistAccount specialistAccount = db.SpecialistAccounts.Find(id);

            return View(specialistAccount);
        }

        public ActionResult Questions(int id)
        {
            ViewBag.SpecialistId = id;

            List<Question> questions = new List<Question>();

            foreach(Question question in db.Questions)
            {
                if (question.AnswerText == "not answered yet")
                questions.Add(question);
            }
            

            return View(questions);
        }

        public ActionResult AddArticle(int id)
        {
            ViewBag.SpecialistId = id;
            return View();
        }

        public ActionResult Article(int idArticle, int idSpecialist)
        {
            Article article = db.Articles.Find(idArticle);
            ViewBag.SpecialistId = idSpecialist;
            return View(article);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditAccount([Bind(Include = "Id,FirstName,LastName,Email,Password,CliniqueName,University,DiplomaNumber,Validation")] SpecialistAccount specialistAccount)
        {            
            if (ModelState.IsValid)
            {
                db.Entry(specialistAccount).State = EntityState.Modified;
                db.SaveChanges();

                TempData["Message"] = "Changes have been saved.";

            }
            else
            {
                TempData["Message"] = "No changes have been saved.";
            }
            return View(specialistAccount);
        }
        public ActionResult SkinProductsList(int id)
        {
            ViewBag.SpecialistId = id;
            return View(db.SkinProducts.ToList());
        }
        public ActionResult EditSkinProducts(int? id, int idSpecialist)
        {
            ViewBag.SpecialistId = idSpecialist;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            SkinProduct skinProduct = db.SkinProducts.Find(id);
            List<string> s = new List<string>();
            List<string> c = new List<string>();

            s.Add(skinProduct.SkinType);
            ViewBag.SkinTypes = s;

            c.Add(skinProduct.Category);
            ViewBag.skinproductcategories = c;

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
        public async Task<ActionResult> EditSkinProducts([Bind(Include = "Id,ProductName,Description,SkinType,Category,ImageUrl,ImageData")] SkinProduct skinProduct)
        {
            using (var client = new HttpClient())
            {
                var imageData = await client.GetByteArrayAsync(skinProduct.ImageUrl);
                skinProduct.ImageData = imageData;

            }
            if (ModelState.IsValid)
            {
                db.Entry(skinProduct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("SkinProductsList");
            }
            return View(skinProduct);
        }

        public ActionResult AddSkinProduct(int id)
        {
            ViewBag.SpecialistId = id;
            Skin skinTypes = new Skin();
            List<string> skinTypesList = skinTypes.skinTypes;
            ViewBag.SkinTypes = skinTypesList;


            SkinProductCategories categories = new SkinProductCategories();
            List<string> categoriesList = categories.skinproductcategories;
            ViewBag.skinproductcategories = categoriesList;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddSkinProduct([Bind(Include = "Id,ProductName,Description,SkinType,Category,ImageUrl,ImageData")] SkinProduct skinProduct)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var imageData = await client.GetByteArrayAsync(skinProduct.ImageUrl);
                    skinProduct.ImageData = imageData;

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
                return RedirectToAction("SkinProductsList");
            }

          

            return View(skinProduct);
        }
        public ActionResult DeleteSkinProduct(int? id)
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteSkinProduct(int id)
        {
            SkinProduct skinProduct = db.SkinProducts.Find(id);
            db.SkinProducts.Remove(skinProduct);
            db.SaveChanges();
            return RedirectToAction("SkinProductsList");
        }
        public ActionResult DetailsSkinProduct(int? id, int idSpecialist)
        {
            ViewBag.SpecialistId = idSpecialist;
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
        //HAIR
        public ActionResult HairProductsList(int id)
        {
            ViewBag.SpecialistId = id;
            return View(db.HairProducts.ToList());
        }
        public ActionResult AddHairProduct(int id)
        {
            ViewBag.SpecialistId = id;
            Hair hairTypes = new Hair();
            List<string> hairTypesList = hairTypes.hairTypes;
            ViewBag.HairTypes = hairTypesList;

            HairProductCategories categories = new HairProductCategories();
            List<string> categoriesList = categories.Hairproductcategories;
            ViewBag.Hairproductcategories = categoriesList;

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddHairProduct([Bind(Include = "Id,ProductName,Description,HairType,Category,ImageUrl,ImageData")] HairProduct hairProduct)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var imageData = await client.GetByteArrayAsync(hairProduct.ImageUrl);
                    hairProduct.ImageData = imageData;

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
                return RedirectToAction("HairProductsList");
            }

            return View(hairProduct);
        }
        public ActionResult EditHairProduct(int? id, int idSpecialist)
        {
            ViewBag.SpecialistId = idSpecialist;
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditHairProduct([Bind(Include = "Id,ProductName,Description,HairType,Category,ImageUrl,ImageData")] HairProduct hairProduct)
        {
            using (var client = new HttpClient())
            {
                var imageData = await client.GetByteArrayAsync(hairProduct.ImageUrl);
                hairProduct.ImageData = imageData;

            }
            if (ModelState.IsValid)
            {
                db.Entry(hairProduct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("HairProductsList");
            }
            return View(hairProduct);
        }
        public ActionResult DeleteHairProduct(int? id, int idSpecialist)
        {
            ViewBag.SpecialistId = idSpecialist;
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
        public ActionResult DetailsHairProduct(int? id, int idSpecialist)
        {
            ViewBag.SpecialistId = idSpecialist;
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteHairProduct(int id)
        {
            HairProduct hairProduct = db.HairProducts.Find(id);
            db.HairProducts.Remove(hairProduct);
            db.SaveChanges();
            return RedirectToAction("HairProductsList");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Questions(FormCollection form, int id)
        {
            ViewBag.SpecialistId = id;
            
            int index = int.Parse(form["questionIndex"]);
            int questionId = int.Parse(form["questionId"]);
            string answerText = form[string.Format("[{0}].AnswerText", index)];
           
            if (answerText != null)
            {
                Question question = db.Questions.Find(questionId);
                question.AnswerText = answerText;

                SpecialistAccount specialist = db.SpecialistAccounts.Find(id);
                question.AnsweredBy = specialist.FirstName + " " + specialist.LastName;                        

                db.SaveChanges();

                TempData["Message"] = "Answer submitted.";

            }

            List<Question> questions = new List<Question>();          

            foreach (Question question in db.Questions)
            {
                if (question.AnswerText == "not answered yet")
                    questions.Add(question);
            }


            return View(questions);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddArticle([Bind(Include = "Title, Author, ArticleText")] Article article, int id)
        {
            ViewBag.SpecialistId = id;
            if (ModelState.IsValid)
            {
                article.IdSpecialist = id;
                db.Articles.Add(article);
                db.SaveChanges();

                TempData["Message"] = "Article added successfully!";
            }

            return View();
        }
    }

}