using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using FlatRent.Entities;
using FlatRent.Models;

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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != flat.ID)
            {
                return BadRequest();
            }

            db.Entry(flat).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FlatExists(id))
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

        // POST: api/Flats
        [ResponseType(typeof(Flat))]
        public IHttpActionResult PostFlat(Flat flat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Flats.Add(flat);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = flat.ID }, flat);
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