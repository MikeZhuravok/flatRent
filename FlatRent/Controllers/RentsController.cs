﻿using System;
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
    public class RentsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public IQueryable<Rent> GetRents()
        {
            return db.Rents;
        }

        [ResponseType(typeof(IEnumerable<Rent>))]
        public IHttpActionResult GetRents(string userEmail)
        {
            ApplicationUser user = db.Users.FirstOrDefault(p => p.Email == userEmail);
            if (user == null)
            {
                return NotFound();
            }
            IEnumerable<Rent> rents = db.Rents.Where(p => p.RentingUser.Id == user.Id).ToList();
            if (rents == null)
            {
                return NotFound();
            }

            return Ok(rents);
        }

        // PUT: api/Rents/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRent(int id, Rent rent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rent.ID)
            {
                return BadRequest();
            }

            db.Entry(rent).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RentExists(id))
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

        // POST: api/Rents
        [ResponseType(typeof(Rent))]
        public IHttpActionResult PostRent(Rent rent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Rents.Add(rent);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = rent.ID }, rent);
        }

        // DELETE: api/Rents/5
        [ResponseType(typeof(Rent))]
        public IHttpActionResult DeleteRent(int id)
        {
            Rent rent = db.Rents.Find(id);
            if (rent == null)
            {
                return NotFound();
            }

            db.Rents.Remove(rent);
            db.SaveChanges();

            return Ok(rent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RentExists(int id)
        {
            return db.Rents.Count(e => e.ID == id) > 0;
        }
    }
}