using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using FlatRent.Entities;
using FlatRent.Models;

namespace FlatRent.Controllers
{
    public class FacilityInFlatsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/FacilityInFlats
        public IQueryable<FacilityInFlat> GetFacilityInFlats()
        {
            return db.FacilityInFlats;
        }

        // GET: Facilities in flat N"id"
        [ResponseType(typeof(List<Facility>))]
        public IHttpActionResult GetFacilityInFlat(int id)
        {
            FacilityInFlat facilityInFlat = db.FacilityInFlats.Find(id);
            if (facilityInFlat == null)
            {
                return NotFound();
            }
            List<Facility> facilities = db.FacilityInFlats.Where(i => i.FlatId == id).Select(i => i.Facility).ToList();
            return Ok(facilities);
        }

        // PUT: api/FacilityInFlats/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFacilityInFlat(int id, FacilityInFlat facilityInFlat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != facilityInFlat.ID)
            {
                return BadRequest();
            }

            db.Entry(facilityInFlat).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FacilityInFlatExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/FacilityInFlats
        [ResponseType(typeof(FacilityInFlat))]
        public IHttpActionResult PostFacilityInFlat(FacilityInFlat facilityInFlat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.FacilityInFlats.Add(facilityInFlat);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = facilityInFlat.ID }, facilityInFlat);
        }

        // DELETE: api/FacilityInFlats/5
        [ResponseType(typeof(FacilityInFlat))]
        public IHttpActionResult DeleteFacilityInFlat(int id)
        {
            FacilityInFlat facilityInFlat = db.FacilityInFlats.Find(id);
            if (facilityInFlat == null)
            {
                return NotFound();
            }

            db.FacilityInFlats.Remove(facilityInFlat);
            db.SaveChanges();

            return Ok(facilityInFlat);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FacilityInFlatExists(int id)
        {
            return db.FacilityInFlats.Count(e => e.ID == id) > 0;
        }
    }
}