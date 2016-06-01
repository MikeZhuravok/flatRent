using FlatRent.Entities;
using FlatRent.Web.App_Start;
using FlatRent.Web.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Mvc;

namespace FlatRent.Web.Controllers
{
    public class HomeController : Controller
    {
        public async System.Threading.Tasks.Task<ActionResult> Index()
        {

            IEnumerable<Flat> model = await ApiContacter.GetFlats();
            return View(model);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult AddPicture()
        {
            ViewBag.Message = "Add picture to DB.";

            return View();
        }
        
    }
}