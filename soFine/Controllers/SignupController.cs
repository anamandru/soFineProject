using soFine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace soFine.Controllers
    {
        public class SignupClientController : Controller
        {
            private SoFineDB db = new SoFineDB();

            // GET: SignupClient/Create
            public ActionResult SignupClient()
            {
                return View();
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult SignupClient([Bind(Include = "Id,FirstName,LastName,Email,Password")] UserAccount userAccount)
            {

                UserAccount userAccountCheck = db.UserAccounts.FirstOrDefault(m => (m.Email == userAccount.Email));
                var emailCheck = new EmailAddressAttribute();
                if (ModelState.IsValid)
                {
                    if (!emailCheck.IsValid(userAccount.Email))
                    {
                        ModelState.AddModelError("Email", "Email is invalid!");
                        return View();
                    }
                    else if (userAccountCheck != null)
                    {
                        ModelState.AddModelError("Email", "Email already exists.");
                    return View(); ;

                }
                else
                    {
                        db.UserAccounts.Add(userAccount);
                        db.SaveChanges();
                    }

                }
                return RedirectToAction("FirstPage", "User", new { id = userAccount.Id });
            }
        }
    }


        