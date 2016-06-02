using FlatRent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FlatRent.Controllers
{
    [Authorize]
    public class ValuesController : ApiController
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public string Get(string userEmail)
        {
            string phone = db.Users.FirstOrDefault(i => i.Email == userEmail).PhoneNumber;
            return phone;
        }
    }
}
