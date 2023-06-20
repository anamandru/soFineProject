using soFine.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace soFine.Controllers
{
    public class SignupSpecialistController : Controller
    {
        private SoFineDB db = new SoFineDB();
        // GET: SignupSpecialist
        public ActionResult SignupSpecialist()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignupSpecialist([Bind(Include = "Id,FirstName,LastName,Email,Password,CliniqueName,University,DiplomaNumber,Validation")] SpecialistAccount specialistAccount)
        {

            SpecialistAccount specialistAccountCheck = db.SpecialistAccounts.FirstOrDefault(m => (m.Email == specialistAccount.Email));
            var emailCheck = new EmailAddressAttribute();
            if (ModelState.IsValid)
            {
                if (!emailCheck.IsValid(specialistAccount.Email))
                {
                    ModelState.AddModelError("Email", "Email is invalid!");
                    return View();
                }
                else if (specialistAccountCheck != null)
                {
                    ModelState.AddModelError("Email", "Email already exists.");
                    return View();
                }
                else
                {
                    db.SpecialistAccounts.Add(specialistAccount);
                    db.SaveChanges();
                }
            }
            
             return RedirectToAction("LoginValidation", "Specialist", new { id = specialistAccount.Id });
            

        }
    }
}