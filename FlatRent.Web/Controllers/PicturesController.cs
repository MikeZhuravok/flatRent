using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FlatRent.Entities;
using FlatRent.Web.App_Start;
using System.Net.Http;

namespace FlatRent.Web.Controllers
{
    public class PicturesController : Controller
    {

        // GET: Pictures
        public async System.Threading.Tasks.Task<ActionResult> Index()
        {
            IEnumerable<Picture> model;
            using (var client = new HttpClient())
            {
                var uri = new Uri(StaticData.ApiLink + "api/Pictures");

                var response = await client.GetAsync(uri);

                string textResult = await response.Content.ReadAsStringAsync();

                model = System.Web.Helpers.Json.Decode<IEnumerable<Picture>>(textResult);
            }
            return View(model);
        }

        // GET: Pictures/Create
        public ActionResult Create()
        {
            return View();
        }
        
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }           
        //}
            
    }
}
