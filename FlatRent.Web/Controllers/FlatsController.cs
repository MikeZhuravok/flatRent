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
using Microsoft.VisualBasic;

namespace FlatRent.Web.Controllers
{
    public class FlatsController : Controller
    {

        public async System.Threading.Tasks.Task<ActionResult> Index()
        {
            IEnumerable<Flat> model = await ApiContacter.GetFlats();
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
            IEnumerable<Facility> facilities = await ApiContacter.GetFacilitiesByFlat(id);

            model.Flat = flat;
            model.Facilities = facilities;


            return View(model);
        }

        public async System.Threading.Tasks.Task<ActionResult> Create()
        {
            if (HttpContext.Request.Cookies["token"] == null)
            {
                return View("NoSuchRules");
            }
            ComplexFlat model = new ComplexFlat();
            var facilities = await ApiContacter.GetFacilities();
            model.FacilitiesSelection = new MultiSelectList(facilities.Select(i => i.Type).ToList());
            return View(model);
        }

        public async System.Threading.Tasks.Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flat flat = await ApiContacter.GetFlat(id);           
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
            Flat flat = await ApiContacter.GetFlat(id);
            return View(flat);
        }

        public async System.Threading.Tasks.Task<ActionResult> RentAFlat(int? id)
        {
            Flat flat = await ApiContacter.GetFlat(id);
            return View(new Rent() { FlatId = flat.ID });
        }

        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> RentAFlat(Rent rent)
        {
            Flat flat = await ApiContacter.GetFlat(rent.FlatId);
            DateInterval interval = DateInterval.Day;
            long difference = DateAndTime.DateDiff(interval, rent.StartOfRent, rent.EndOfRent, FirstDayOfWeek.Monday);  
            decimal price = difference > 30 == true ? flat.PriceForMonth / 30 * difference : flat.PriceForDay* difference;
            ViewBag.Price = price;
            return View("Confirmation", rent);
        }
    }
}
