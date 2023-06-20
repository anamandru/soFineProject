using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MimeKit;
using soFine.HelperClasses;
using soFine.Models;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;
using MailKit.Security;
using System.Threading.Tasks;

namespace soFine.Controllers
{
    public class LoginController : Controller
    {
        private SoFineDB db = new SoFineDB();
        // GET: Login
        public ActionResult Home()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }        

        public ActionResult SendPasswordMail()
        {

            return View();
        }        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "Email,Password")] User user)
        {
            string domain;
            if (user.Email != null)
            {
                domain = user.Email.Substring(user.Email.IndexOf("@") + 1);
            }
            else
            {
                ModelState.AddModelError("Email", "Email is required.");
                return View();
            }

            if (user.Password == "admin" && domain == "admin.com")
            {
                return RedirectToAction("Home", "Admin");
            }
            else 
            { 
            UserAccount userAccount = db.UserAccounts.FirstOrDefault(m => m.Email == user.Email);
            SpecialistAccount specialistAccount = db.SpecialistAccounts.FirstOrDefault(m => m.Email == user.Email);
                 
            if (ModelState.IsValid)
            {              
                
                    var emailCheck = new EmailAddressAttribute();

                    if (!emailCheck.IsValid(user.Email))
                    {
                        ModelState.AddModelError("Email", "Email is invalid");
                        return View();
                    }
                    else
                    {
                        if (userAccount != null)
                        {
                            if (userAccount.Password == user.Password)
                            {
                                return RedirectToAction("FirstPage", "User", new {id = userAccount.Id});
                            }
                            else
                            {
                                ModelState.AddModelError("Password", "Incorrect password");
                                return View();
                            }
                        }
                        else if (specialistAccount != null)
                        {
                            if (specialistAccount.Password == user.Password)
                            {
                                if (specialistAccount.Validation == false)
                                {
                                    return RedirectToAction("LoginValidation", "Specialist", new { id = specialistAccount.Id });
                                }
                                else
                                {
                                    return RedirectToAction("FirstPage", "Specialist", new { id = specialistAccount.Id });
                                }
                            }
                            else
                            {
                                ModelState.AddModelError("Password", "Incorrect password");
                                return View();
                            }
                        }
                        else
                        {
                            ModelState.AddModelError("Email", "This email is not associated to any existent account.");
                            return View();
                        }
                    }
                }
                return RedirectToAction("Index", "Home");
            }

           

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SendPasswordMail([Bind(Include = "Email,Password")] User user)
        {
            var emailCheck = new EmailAddressAttribute();

            if (user.Email == null)
            {
                ModelState.AddModelError("Email", "Email is required.");
                return View();
            }
            else {
                if (!emailCheck.IsValid(user.Email))
                {
                    ModelState.AddModelError("Email", "Email is invalid");
                    return View();
                }
                else
                {
                    ModelState.AddModelError("Email", "Check the inbox");
                    var email = new MimeMessage();

                    UserAccount userAccount = db.UserAccounts.FirstOrDefault(x => x.Email == user.Email);
                    string receiveremail = user.Email;

                    email.To.Add(new MailboxAddress("Receiver", receiveremail));
                    email.From.Add(new MailboxAddress("soFine", "ilincamariabalabasciuc@yahoo.com"));

                    email.Subject = "Recover your password";

                    if (userAccount != null)
                    {
                        email.Body = new TextPart(MimeKit.Text.TextFormat.Plain)
                        {
                            Text = "Hey " + userAccount.FirstName.ToString() + ", there is your password: " + userAccount.Password.ToString()
                        };
                    }
                    else
                    {
                        email.Body = new TextPart(MimeKit.Text.TextFormat.Plain)
                        {
                            Text = "This email is not associated with an account. Try to create an account."
                        };
                    }

                    using (var smtp = new SmtpClient())
                    {
                        smtp.Connect("smtp.mail.yahoo.com", 587, false);
                        smtp.AuthenticationMechanisms.Remove("XOAUTH2");

                        smtp.Authenticate("ilincamariabalabasciuc", "fjkbhvbqigbcynmz");

                        smtp.Send(email);
                        smtp.Disconnect(true);
                    }

                    return View();
                }
            }                
        }
    }
}