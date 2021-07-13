using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EMS.Models.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

namespace ASP.NET_MVC.Controllers
{
    public class AccountController : Controller
    {
        // Register: Account
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegVM model)
        {
            if (ModelState.IsValid)
            {
                var userStore = new UserStore<IdentityUser>();
                var userManager = new UserManager<IdentityUser>(userStore);
                var user = new IdentityUser { UserName = model.UserNmae, Email = model.Email };
                var result = userManager.Create(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    ModelState.AddModelError("", "Registration Failed");
                    return View(model);
                }
            }
            return View(model);
        }

        //Login:Account
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                var userStore = new UserStore<IdentityUser>();
                var userManager = new UserManager<IdentityUser>(userStore);
                var user = userManager.Find(model.UserName, model.Password);
                if (user != null)
                {
                    var authManager = System.Web.HttpContext.Current.GetOwinContext().Authentication;
                    authManager.SignIn(new AuthenticationProperties() { }, userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie));
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Login Failed!!");
                    return View(model);
                }
            }
            return View(model);
        }

        //Logout:Account
        [Authorize]
        public ActionResult Logout()
        {
            var authManager = System.Web.HttpContext.Current.GetOwinContext().Authentication;
            authManager.SignOut();
            return RedirectToAction("Login", "Account");
        }
    }
}
