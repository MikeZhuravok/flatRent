using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FlatRent.Entities;
using System.Net.Http;
using FlatRent.Web.App_Start;

namespace FlatRent.Web.Controllers
{
    public class FacilitiesController : Controller
    {
        public async System.Threading.Tasks.Task<ActionResult> Index()
        {
            IEnumerable<Facility> model;
            using (var client = new HttpClient())
            {
                var uri = new Uri(StaticData.ApiLink + "api/Facilities");

                var response = await client.GetAsync(uri);

                string textResult = await response.Content.ReadAsStringAsync();

                model = System.Web.Helpers.Json.Decode<IEnumerable<Facility>>(textResult);
            }
            return View(model);
        }      

        public ActionResult Create()
        {
            ViewBag.PostLink = StaticData.ApiLink + "Facilities/";
            return View();
        }
        


        //// GET: Facilities/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Facility facility = db.Facilities.Find(id);
        //    if (facility == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(facility);
        //}


        //// GET: Facilities/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Facility facility = db.Facilities.Find(id);
        //    if (facility == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(facility);
        //}     
    }
}
