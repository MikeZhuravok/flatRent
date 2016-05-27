using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FlatRent.Entities;
using FlatRent.Web.Models;
using System.Net.Http;
using FlatRent.Web.App_Start;

namespace FlatRent.Web.Controllers
{
    public class FlatsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public async System.Threading.Tasks.Task<ActionResult> Index()
        {
            IEnumerable<Flat> model;
            using (var client = new HttpClient())
            {
                var uri = new Uri(StaticData.ApiLink + "api/Flats");

                var response = await client.GetAsync(uri);

                string textResult = await response.Content.ReadAsStringAsync();

                model = System.Web.Helpers.Json.Decode<IEnumerable<Flat>>(textResult);
            }
            return View(model);
        }


        public async System.Threading.Tasks.Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flat flat;
            using (var client = new HttpClient())
            {
                var uri = new Uri(StaticData.ApiLink + "api/Pictures");

                var response = await client.GetAsync(uri);

                string textResult = await response.Content.ReadAsStringAsync();

                flat = System.Web.Helpers.Json.Decode<Flat>(textResult);
            }
            return View(flat);
        }

        public ActionResult Create()
        {
            return View();
        }

        //    // GET: Flats/Edit/5
        //    public ActionResult Edit(int? id)
        //    {
        //        if (id == null)
        //        {
        //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //        }
        //        Flat flat = db.Flats.Find(id);
        //        if (flat == null)
        //        {
        //            return HttpNotFound();
        //        }
        //        return View(flat);
        //    }      

        //public async System.Threading.Tasks.Task<ActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    using (var client = new HttpClient())
        //    {
        //        var uri = new Uri(StaticData.ApiLink + "api/Flats/" + id);

        //        var response = await client.GetAsync(uri);

        //        string textResult = await response.Content.ReadAsStringAsync();

        //        //model = System.Web.Helpers.Json.Decode<IEnumerable<Flat>>(textResult);
        //    }
        //    //return View(model);
        //}
        
    }
}
