using MailKit.Search;
using Newtonsoft.Json;
using soFine.Enums;
using soFine.HelperClasses;
using soFine.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;


namespace soFine.Controllers
{

    public class UserController : Controller
    {
        private SoFineDB db = new SoFineDB();
        // GET: User
        public ActionResult Home(int id)
        {
            ViewBag.UserId = id;
            UserAccount userAccount = db.UserAccounts.Find(id);

            //skin
            SkinProductCategories skinProductCategories = new SkinProductCategories();
            List<string> skinProductCategoriesList = skinProductCategories.skinproductcategories;
            List<string> findCategorySkin = new List<string>();
            List<SkinProduct> usersProductsSkin = new List<SkinProduct>();

            
            foreach(string cat in skinProductCategoriesList)
            {
                foreach(UsersSkinProduct skinProduct in db.UsersSkinProducts)
                {
                    
                    SkinProduct product = db.SkinProducts.Find(skinProduct.ProductId);
                    if (product != null)
                    {
                        if (skinProduct.UserId == id && product.Category == cat)
                        {
                            usersProductsSkin.Add(product);
                        }
                        if (product.Category == cat && !findCategorySkin.Contains(product.Category))
                        {
                            findCategorySkin.Add(product.Category);
                        }
                    }
                }
            }

            ViewBag.UserSkinCategories = findCategorySkin;
            ViewBag.SkinProducts = usersProductsSkin;

            //hair
            HairProductCategories hairProductCategories = new HairProductCategories();
            List<string> hairProductCategoriesList = hairProductCategories.Hairproductcategories;
            List<string> findCategoryHair = new List<string>();
            List<HairProduct> usersProductsHair = new List<HairProduct>();

            foreach (string cat in hairProductCategoriesList)
            {
                foreach (UsersHairProduct hairProduct in db.UsersHairProducts)
                {

                    HairProduct product = db.HairProducts.Find(hairProduct.ProductId);
                    if (hairProduct.UserId == id && product.Category == cat)
                    {
                        usersProductsHair.Add(product);
                    }
                    if (product.Category == cat && !findCategoryHair.Contains(product.Category))
                    {
                        findCategoryHair.Add(product.Category);
                    }
                }
            }

            ViewBag.UserHairCategories = findCategoryHair;
            ViewBag.HairProducts = usersProductsHair;
            //
            return View(userAccount);
        }

        public ActionResult FirstPage(int id)
        {
            ViewBag.UserId = id;

            List<Article> articles = new List<Article>();

            foreach (Article article in db.Articles)
            {
                articles.Add(article);
            }

            return View(articles);
           
        }

        public ActionResult AskQuestion(int id)
        {
            ViewBag.UserId = id;
            Question question = new Question();
            return View(question);
        }

        public ActionResult Questions(int id)
        {
            ViewBag.UserId = id;

            List<Question> questionList = new List<Question>();

            foreach(Question question in db.Questions)
            {
                if (question.IdUser == id)
                {
                    questionList.Add(question);
                }
            }
            return View(questionList);
        }

        public ActionResult SkinProductDetails(int? id, int iduser)
        {

            ViewBag.UserId = iduser;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SkinProduct skinProduct = db.SkinProducts.Find(id);
            if (skinProduct == null)
            {
                return HttpNotFound();
            }

            UsersSkinProduct product = db.UsersSkinProducts.FirstOrDefault(m => (m.ProductId == id && m.UserId == iduser));

            if (product == null)
            {
                ViewBag.Exists = false;
            }
            else
            {
                ViewBag.Exists = true;
            }

            return View(skinProduct);
        }

        public ActionResult HairProductDetails(int? id, int iduser)
        {

            ViewBag.UserId = iduser;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HairProduct hairProduct = db.HairProducts.Find(id);
            if (hairProduct == null)
            {
                return HttpNotFound();
            }

            UsersHairProduct product = db.UsersHairProducts.FirstOrDefault(m => (m.ProductId == id && m.UserId == iduser));

            if (product == null)
            {
                ViewBag.Exists = false;
            }
            else
            {
                ViewBag.Exists = true;
            }

            return View(hairProduct);
        }

        public ActionResult SkinRoutine(int id)
        {
            ViewBag.UserId = id;
            UserAccount user = db.UserAccounts.Find(id);
            SkinProductCategories skinProductCategories = new SkinProductCategories();
            List<string> skinProductCategoriesList = skinProductCategories.skinproductcategories;
            ViewBag.skinproductcategories = skinProductCategoriesList;

            List<SkinProduct> skinProducts = new List<SkinProduct>();
            
            ViewBag.Products = "";
            return View(skinProducts);
        }

        public ActionResult HairRoutine(int id)
        {
            ViewBag.UserId = id;
            UserAccount user = db.UserAccounts.Find(id);
            HairProductCategories hairProductCategories = new HairProductCategories();
            List<string> hairProductCategoriesList = hairProductCategories.Hairproductcategories;
            ViewBag.hairproductcategories = hairProductCategoriesList;

            List<HairProduct> hairProducts = new List<HairProduct>();

            ViewBag.Products = "";
            return View(hairProducts);
        }


        public ActionResult About(int id)
        {
            ViewBag.UserId = id;
            return View();
        }

        
        public ActionResult SkinQuiz(int id)
        {
            ViewBag.UserId = id;

            List<string> skinQuiz = new List<string>();

            foreach (SkinQuiz question in db.SkinQuizs)
            {
                skinQuiz.Add(question.Question);
            }
            ViewBag.Questions = skinQuiz;

            List<string> skinQuizAnswers = new List<string>();

            foreach (SkinAnswer answer in db.SkinAnswers)
            {
                skinQuizAnswers.Add(answer.Text);
            }

            ViewBag.Answers = skinQuizAnswers;

            return View();
        }

        public ActionResult HairQuiz(int id)
        {
            ViewBag.UserId = id;

            List<string> hairQuiz = new List<string>();

            foreach (HairQuiz question in db.HairQuizs)
            {
                hairQuiz.Add(question.Question);
            }
            ViewBag.Questions = hairQuiz;

            List<string> hairQuizAnswers = new List<string>();

            foreach (HairAnswer answer in db.HairAnswers)
            {
                hairQuizAnswers.Add(answer.Text);
            }

            ViewBag.Answers = hairQuizAnswers;

            return View();
        }

        // GET: UserAccounts/Edit/5
        public ActionResult EditAccount(int? id)
        {
            ViewBag.UserId = id;
            UserAccount userAccount = db.UserAccounts.Find(id);
            List<string> s = new List<string>();
            List<string> h = new List<string>();

            if (userAccount.SkinType != null)
            {

                s.Add(userAccount.SkinType);
                ViewBag.SkinTypes = s;
            }
            else
            {
                s.Add("Take the quiz");
                ViewBag.SkinTypes = s;
            }

            if (userAccount.HairType != null)
            {
                h.Add(userAccount.HairType);
                ViewBag.HairTypes = h;
            }
            else
            {
                h.Add("Take the quiz");
                ViewBag.HairTypes = h;
            }

            return View(userAccount);
        }

        public ActionResult Article(int idArticle, int idUser)
        {
            Article article = db.Articles.Find(idArticle);
            ViewBag.UserId = idUser;
            return View(article);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditAccount([Bind(Include = "Id,FirstName,LastName,Email,Password,SkinType,HairType")] UserAccount userAccount)
        {
            List<string> s = new List<string>();
            List<string> h = new List<string>();

            

            if (userAccount.SkinType != null)
            {

                s.Add(userAccount.SkinType);
                ViewBag.SkinTypes = s;
            }
            else
            {
                s.Add("Take the quiz");
                ViewBag.SkinTypes = s;
            }

            if (userAccount.HairType != null)
            {
                h.Add(userAccount.HairType);
                ViewBag.HairTypes = h;
            }
            else
            {
                h.Add("Take the quiz");
                ViewBag.HairTypes = h;
            }

            if (ModelState.IsValid)
            {
                db.Entry(userAccount).State = EntityState.Modified;
                db.SaveChanges();

                TempData["Message"] = "Changes have been saved.";

            }
            else
            {
                TempData["Message"] = "No changes have been saved.";
            }
            return View(userAccount);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SkinQuiz(FormCollection form, int id)
        {
            ViewBag.UserId = id;
            Skin skinTypes = new Skin();
            List<string> skinTypesList = skinTypes.skinTypes;

            int normal = 0, dry = 0, oily = 0, combination = 0, sensitive = 0;

            if (form.AllKeys.Count() == 6)
            {
                
                foreach (var key in form.AllKeys)
                {
                    if (key.StartsWith("Question"))
                    {
                        string selectedOption = form[key];
                        SkinAnswer skinAnswer = db.SkinAnswers.FirstOrDefault(m => m.Text == selectedOption);
                        int answerId = skinAnswer.Id % 5;
                        switch (answerId)
                        {
                            case 1: normal++; break;
                            case 2: dry++; break;
                            case 3: oily++; break;
                            case 4: combination++; break;
                            case 0: sensitive++; break;
                        }
                    }
                }
           

            List<int> variants = new List<int>{normal, dry, oily, combination, sensitive};
            int maxIndex = variants.FindIndex(num => num == variants.Max());

            string skinType = skinTypesList[maxIndex];

            UserAccount userAccount = db.UserAccounts.Find(id);         
            userAccount.SkinType = skinType;
            db.SaveChanges();
                return RedirectToAction("Home", "User", new { Id = id });
            }

            TempData["Message"] = "You must answer all questions!";

            List<string> skinQuiz = new List<string>();

            foreach (SkinQuiz question in db.SkinQuizs)
            {
                skinQuiz.Add(question.Question);
            }
            ViewBag.Questions = skinQuiz;

            List<string> skinQuizAnswers = new List<string>();

            foreach (SkinAnswer answer in db.SkinAnswers)
            {
                skinQuizAnswers.Add(answer.Text);
            }

            ViewBag.Answers = skinQuizAnswers;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult HairQuiz(FormCollection form, int id)
        {
            ViewBag.UserId = id;
            Hair hairTypes = new Hair();
            List<string> hairTypesList = hairTypes.hairTypes;

            int oily = 0, normal = 0, dry = 0, curly = 0;

            if (form.AllKeys.Count() == 6)
            {
                foreach (var key in form.AllKeys)
                {
                    if (key.StartsWith("Question"))
                    {
                        string selectedOption = form[key];
                        HairAnswer hairAnswer = db.HairAnswers.FirstOrDefault(m => m.Text == selectedOption);
                        int answerId = hairAnswer.Id % 4;
                        switch (answerId)
                        {
                            case 1: oily++; break;
                            case 2: normal++; break;
                            case 3: dry++; break;
                            case 0: curly++; break;
                        }
                    }
                }

                List<int> variants = new List<int> { oily, normal, dry, curly };
                int maxIndex = variants.FindIndex(num => num == variants.Max());

                string hairType = hairTypesList[maxIndex];

                UserAccount userAccount = db.UserAccounts.Find(id);
                userAccount.HairType = hairType;
                db.SaveChanges();

                return RedirectToAction("Home", "User", new { Id = id });
            }

            TempData["Message"] = "You must answer all questions!";

            List<string> hairQuiz = new List<string>();

            foreach (HairQuiz question in db.HairQuizs)
            {
                hairQuiz.Add(question.Question);
            }
            ViewBag.Questions = hairQuiz;

            List<string> hairQuizAnswers = new List<string>();

            foreach (HairAnswer answer in db.HairAnswers)
            {
                hairQuizAnswers.Add(answer.Text);
            }

            ViewBag.Answers = hairQuizAnswers;
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SkinRoutine(string Category, int id)
        {
           
            ViewBag.UserId = id;
            UserAccount userAccount = db.UserAccounts.Find(id);
            SkinProductCategories skinProductCategories = new SkinProductCategories();
            List<string> skinProductCategoriesList = skinProductCategories.skinproductcategories;
            ViewBag.skinproductcategories = skinProductCategoriesList;

            List<SkinProduct> skinProducts = new List<SkinProduct>();

            foreach(SkinProduct skinProduct in db.SkinProducts) { 
            if (skinProduct.Category == Category && skinProduct.SkinType == userAccount.SkinType)
                {
                    skinProducts.Add(skinProduct);
                }
                    }

            return View(skinProducts);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult HairRoutine(string Category, int id)
        {

            ViewBag.UserId = id;
            UserAccount userAccount = db.UserAccounts.Find(id);
            HairProductCategories hairProductCategories = new HairProductCategories();
            List<string> hairProductCategoriesList = hairProductCategories.Hairproductcategories;
            ViewBag.hairproductcategories = hairProductCategoriesList;

            List<HairProduct> hairProducts = new List<HairProduct>();

            foreach (HairProduct hairProduct in db.HairProducts)
            {
                if (hairProduct.Category == Category && hairProduct.HairType == userAccount.HairType)
                {
                    hairProducts.Add(hairProduct);
                }
            }

            return View(hairProducts);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SkinProductDetails(int id, int iduser)
        {
            SkinProduct product = db.SkinProducts.Find(id);

            UsersSkinProduct productExists = db.UsersSkinProducts.FirstOrDefault(m => (m.ProductId == id && m.UserId == iduser));

            if (productExists == null)
            {
                UsersSkinProduct usersProduct = new UsersSkinProduct();
                usersProduct.ProductId = id;
                usersProduct.UserId = iduser;

                db.UsersSkinProducts.Add(usersProduct);

                ViewBag.Exists = true;
            }
            else
            {
                db.UsersSkinProducts.Remove(productExists);
                ViewBag.Exists = false;
            }

            db.SaveChanges();

            ViewBag.UserId = iduser;
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult HairProductDetails(int id, int iduser)
        {
            HairProduct product = db.HairProducts.Find(id);

            UsersHairProduct productExists = db.UsersHairProducts.FirstOrDefault(m => (m.ProductId == id && m.UserId == iduser));

            if (productExists == null)
            {
                UsersHairProduct usersProduct = new UsersHairProduct();
                usersProduct.ProductId = id;
                usersProduct.UserId = iduser;
                db.UsersHairProducts.Add(usersProduct);

                ViewBag.Exists = true;
            }
            else
            {
                db.UsersHairProducts.Remove(productExists);
                ViewBag.Exists = false;
            }
           
            db.SaveChanges();

            ViewBag.UserId = iduser;
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AskQuestion(Question  question, int id) 
        {
            ViewBag.UserId = id;
            question.IdUser = id;
            question.AnswerText = "not answered yet";

            db.Questions.Add(question);

            db.SaveChanges();

            if (ModelState.IsValid)
            {               
                TempData["Message"] = "Your question has been sent.";

            }           

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteSkinProduct(int iduser, int idprod)
        {
            ViewBag.UserId = iduser;

            UsersSkinProduct product = db.UsersSkinProducts.FirstOrDefault(p => p.ProductId == idprod);
            db.UsersSkinProducts.Remove(product);
            db.SaveChanges();

            return RedirectToAction("Home", "User", new { id = iduser });

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteHairProduct(int iduser, int idprod)
        {
            ViewBag.UserId = iduser;

            UsersHairProduct product = db.UsersHairProducts.FirstOrDefault(p => p.ProductId == idprod);
            db.UsersHairProducts.Remove(product);
            db.SaveChanges();

            return RedirectToAction("Home", "User", new { id = iduser });

        }
    }
    }