using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using FlatRent.Entities;
using FlatRent.Models;
using FlatRent.Concrete;
using Geocoding;
using Geocoding.Google;
using System.Collections.Generic;
using System.Web.Http.Results;
using FlatRent.App_Start;
using System.Collections;

namespace FlatRent.Controllers
{ 

    public class FlatsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Flats
        public IQueryable<Flat> GetFlats()
        {
            return db.Flats;
        }

        // GET: api/Flats/5
        [ResponseType(typeof(Flat))]
        public IHttpActionResult GetFlat(int id)
        {
            Flat flat = db.Flats.Find(id);
            if (flat == null)
            {
                return NotFound();
            }

            return Ok(flat);
        }

        // PUT: api/Flats/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFlat(int id, Flat flat)
        {            
            IGeocoder geocoder = new GoogleGeocoder() { ApiKey = "AIzaSyBPv28nNFi9vaIE74qhSfqdUhbGDqj0vyY" };
            IEnumerable<Address> addresses = geocoder.Geocode(flat.Address, flat.City, flat.District, flat.ZipCode.ToString(), flat.Country);

            flat.Latitude = addresses.First().Coordinates.Latitude;
            flat.Longitude = addresses.First().Coordinates.Longitude;

            db.Entry(flat).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!FlatExists(id))
                //{
                //    return NotFound();
                //}
                //else
                //{
                //    throw;
                //}
            }

            return Redirect(StaticData.WebClientLink + "Flats");
        }

        // POST: api/Flats
        [ResponseType(typeof(RedirectResult))]
        public IHttpActionResult PostFlat(ComplexFlat comFlat)
        {
            Flat flat = comFlat.Flat;
            if ((flat.PriceForDay == default(decimal) || flat.PriceForMonth == default(decimal)) && flat.RoomNumber == default(int)
                && flat.Address == null && flat.City == null && flat.Country == null)
            {
                return BadRequest(ModelState);
            }
            IGeocoder geocoder = new GoogleGeocoder() { ApiKey = "AIzaSyBPv28nNFi9vaIE74qhSfqdUhbGDqj0vyY" };
            IEnumerable<Address> addresses = geocoder.Geocode(flat.Address, flat.City, flat.District, flat.ZipCode.ToString(), flat.Country);
            flat.Latitude = addresses.First().Coordinates.Latitude;
            flat.Longitude = addresses.First().Coordinates.Longitude;

            IEnumerable selectedFacilities = comFlat.FacilitiesSelection.SelectedValues;

            db.Flats.Add(flat);
            db.SaveChanges();

            return Redirect(StaticData.WebClientLink + "Flats");
        }

        // DELETE: api/Flats/5
        [ResponseType(typeof(Flat))]
        public IHttpActionResult DeleteFlat(int id)
        {
            Flat flat = db.Flats.Find(id);
            if (flat == null)
            {
                return NotFound();
            }

            db.Flats.Remove(flat);
            db.SaveChanges();

            return Ok(flat);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FlatExists(int id)
        {
            return db.Flats.Count(e => e.ID == id) > 0;
        }
    }
}