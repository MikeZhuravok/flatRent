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
using FlatRent.Web.Concrete;
using System.Collections;

namespace FlatRent.Web.Controllers
{
    public class FacilitiesController : Controller
    {
        public async System.Threading.Tasks.Task<ActionResult> Index()
        {
            IEnumerable<Facility> model = await ApiContacter.GetFacilities();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        public async System.Threading.Tasks.Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Facility facility = await ApiContacter.GetFacility(id);
            if (facility == null)
            {
                return HttpNotFound();
            }
            return View(facility);
        }
    }
}
