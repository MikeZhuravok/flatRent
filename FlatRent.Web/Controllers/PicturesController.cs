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
using FlatRent.Web.Concrete;

namespace FlatRent.Web.Controllers
{
    public class PicturesController : Controller
    {

        public async System.Threading.Tasks.Task<ActionResult> Index()
        {
            ViewBag.Message = "Get pictures from DB.";
            IEnumerable<Picture> model = await ApiContacter.GetPictures();
            return View(model);
        }

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
