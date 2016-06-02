using FlatRent.Entities;
using FlatRent.Web.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlatRent.Web.Controllers
{
    public class RentsController : Controller
    {
        public async System.Threading.Tasks.Task<ActionResult> Index()
        {
            if (HttpContext.Request.Cookies["userEmail"] == null)
            {
                return View("NoSuchRules");
            }
            string userEmail = HttpContext.Request.Cookies["userEmail"].Value;
            IEnumerable<Rent> userRents = await ApiContacter.GetRentsByUserEmail(userEmail);
            return View(userRents);
        } 
    }
}