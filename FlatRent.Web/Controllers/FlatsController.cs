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
using FlatRent.Web.Models.ViewModels;
using FlatRent.Web.Concrete;

namespace FlatRent.Web.Controllers
{
    public class FlatsController : Controller
    {

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
            FlatDetailViewModel model = new FlatDetailViewModel();
            Flat flat = await ApiContacter.GetFlat(id);
            List<Facility> facilities;
            using (var client = new HttpClient())
            {
                var uri = new Uri(StaticData.ApiLink + "api/FacilityInFlats/" + id);

                var response = await client.GetAsync(uri);

                string textResult = await response.Content.ReadAsStringAsync();

                facilities = System.Web.Helpers.Json.Decode<List<Facility>>(textResult);
            }

            model.Flat = flat;
            model.Facilities = facilities;


            return View(model);
        }

        public ActionResult Create()
        {
            if (HttpContext.Request.Cookies["token"] == null)
            {
                return View("NoSuchRules"); 
            }
            return View();
        }

        public async System.Threading.Tasks.Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flat flat;
            using (var client = new HttpClient())
            {
                var uri = new Uri(StaticData.ApiLink + "api/Flats/" + id);

                var response = await client.GetAsync(uri);

                string textResult = await response.Content.ReadAsStringAsync();

                flat = System.Web.Helpers.Json.Decode<Flat>(textResult);
            }
            if (flat == null)
            {
                return HttpNotFound();
            }
            return View(flat);
        }

        public async System.Threading.Tasks.Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flat flat; 
            using (var client = new HttpClient())
            {
                var uri = new Uri(StaticData.ApiLink + "api/Flats/" + id);

                var response = await client.GetAsync(uri);

                string textResult = await response.Content.ReadAsStringAsync();

                flat = System.Web.Helpers.Json.Decode<Flat>(textResult);
            }
            return View(flat);
        }

    }
}
