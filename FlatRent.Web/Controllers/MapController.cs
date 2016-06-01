using FlatRent.Entities;
using FlatRent.Web.Concrete;
using FlatRent.Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlatRent.Web.Controllers
{
    public class MapController : Controller
    {
        // GET: Map
        public async System.Threading.Tasks.Task<ActionResult> ShowMap(int? id)
        {
            Flat flat = await ApiContacter.GetFlat(id);
            MapViewModel model = new MapViewModel()
            {
                Latitude = flat.Latitude,
                Longitude = flat.Longitude,
                Url = Url.Action("Details", "Flats"),
                Address = flat.Address
            };
            return View(model);
        }
    }
}