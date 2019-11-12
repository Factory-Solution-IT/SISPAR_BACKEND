using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Sispar.UI.WebApp.Controllers
{
    public class AccountController : Controller
    {
//        private readonly UserRepository _ctx = new UserRepository();

        public ActionResult LogIn(string returnUrl)
        {
            ViewBag.url = returnUrl;
            return View();
        }

        //[HttpPost]
        //public ActionResult LogIn(User login)
        //{
        //    ModelState.Clear();
        //    var usuario = _ctx.GetByUserName(login.UserName.ToLower());

        //    if (usuario == null)
        //        ModelState.AddModelError("UserName", "User not found");
        //    else
        //    {
        //        if (usuario.Password != login.Password.Encrypt())
        //            ModelState.AddModelError("Password", "Wrong Password");

        //        if (!usuario.Active)
        //            ModelState.AddModelError("", "User Not Active");
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        FormsAuthentication.SetAuthCookie(login.UserName, false);

        //        /*if (!string.IsNullOrEmpty(login.Url) && Url.IsLocalUrl(login.Url))
        //        {
        //            return Redirect(login.Url);
        //        }*/

        //        return RedirectToAction("Index", "Home");
        //    }
        //    return View(login);

        //}

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("LogIn");
        }

        protected override void Dispose(bool disposing)
        {
//            _ctx.Dispose();
        }
    }
}