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

        // GET: Flats
        public async System.Threading.Tasks.Task<ActionResult> Index()
        {
            IEnumerable<Flat> model;
            using (var client = new HttpClient())
            {
                var uri = new Uri(StaticData.ApiLink + "api/Pictures");

                var response = await client.GetAsync(uri);

                string textResult = await response.Content.ReadAsStringAsync();

                model = System.Web.Helpers.Json.Decode<IEnumerable<Flat>>(textResult);
            }
            return View(model);
        }

        // GET: Flats/Details/5
        public async System.Threading.Tasks.Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flat flat;
            using (var client = new HttpClient())
            {
                var uri = new Uri(StaticData.ApiLink + "api/Pictures/" + id);

                var response = await client.GetAsync(uri);

                string textResult = await response.Content.ReadAsStringAsync();

                flat = System.Web.Helpers.Json.Decode<Flat>(textResult);
            }
            return View(flat);
        }

        // GET: Flats/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: Flats/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Flat flat = db.Flats.Find(id);
        //    if (flat == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(flat);
        //}


        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Flat flat = db.Flats.Find(id);
        //    if (flat == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(flat);
        //}

        //// POST: Flats/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Flat flat = db.Flats.Find(id);
        //    db.Flats.Remove(flat);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
