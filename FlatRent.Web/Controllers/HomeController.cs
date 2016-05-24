using FlatRent.Entities;
using FlatRent.Web.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace FlatRent.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
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
        public async System.Threading.Tasks.Task<ActionResult> GetPictures()
        {
            ViewBag.Message = "Get pictures from DB.";
            IEnumerable<Picture> model;
            using (var client = new HttpClient())
            {
                var uri = new Uri(StaticData.ApiLink + "api/Pictures/");

                var response = await client.GetAsync(uri);

                string textResult = await response.Content.ReadAsStringAsync();

                model = System.Web.Helpers.Json.Decode<IEnumerable<Picture>>(textResult);
            }
            return View(model);
        }
    }
    }