using FlatRent.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlatRent.Controllers
{
    public class RentsController : Controller
    {
        public object ApiContacter { get; private set; }

        // GET: Rents
        public async System.Threading.Tasks.Task<ActionResult> Index()
        {
            //cookie
            //IEnumerable<Rent> model = await ApiContacter.GetRents();
            return View();
        }
    }
}