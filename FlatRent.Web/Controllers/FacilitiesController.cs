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
    public class FacilitiesController : Controller
    {
        //private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Facilities
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

        // GET: Facilities/Details/5
        //public ActionResult Details(int? id)
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

        // GET: Facilities/Create
        public ActionResult Create()
        {
            ViewBag.PostLink = StaticData.ApiLink + "Facilities/";
            return View();
        }
        
        //можно сделать пост - проверку на стороне клиента - перед отправкой на сервер


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

        //// POST: Facilities/Edit/5
        //// Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        //// сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "ID,Type,Description")] Facility facility)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(facility).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
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

        //// POST: Facilities/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Facility facility = db.Facilities.Find(id);
        //    db.Facilities.Remove(facility);
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
