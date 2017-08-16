using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Example2.Models;

namespace Example2.Controllers
{
    public class AccountController : Controller
    {
        [Dependency]
        public IFormsAuthenticationService formsAuthenticationService { get; set; }
        //
        // GET: /Account/
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(FormCollection collection)
        {
            if (!string.IsNullOrEmpty(collection["Name"]))
            {
                formsAuthenticationService.SignIn(collection["Name"].ToString(), false);
                return RedirectToAction("Index", "Home");
            }
            return View(collection);
        }

        [AllowAnonymous]
        public ActionResult Logout()
        {
            formsAuthenticationService.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}
