using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlatRent.Web.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Login()
        {
            //var cookie = new HttpCookie("test_cookie")
            //{
            //    Value = DateTime.Now.ToString("dd.MM.yyyy"),
            //    Expires = DateTime.Now.AddMinutes(10),
            //};
            //Response.SetCookie(cookie);
            return View();
        }
    }
}