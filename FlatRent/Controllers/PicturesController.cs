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
using System.Web;
using System.IO;

namespace FlatRent.Controllers
{
    public class PicturesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Pictures
        public IQueryable<Picture> GetPictures()
        {
            return db.Pictures;
        }

        // GET: api/Pictures/5
        [ResponseType(typeof(Picture))]
        public IHttpActionResult GetPicture(int id)
        {
            Picture picture = db.Pictures.Find(id);
            if (picture == null)
            {
                return NotFound();
            }

            return Ok(picture);
        }

        // PUT: api/Pictures/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPicture(int id, Picture picture)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != picture.ID)
            {
                return BadRequest();
            }

            db.Entry(picture).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PictureExists(id))
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

        // POST: api/Pictures
        [ResponseType(typeof(Picture))]
        public IHttpActionResult PostPicture([FromBody]string name, HttpPostedFileBase uploadImage)
        {

            Picture picture = new Picture()
            {
                Name = name
            };
            if (!ModelState.IsValid)
            {
                byte[] imageData = null;
                using (var binaryReader = new BinaryReader(uploadImage.InputStream))
                {
                    imageData = binaryReader.ReadBytes(uploadImage.ContentLength);
                }
                picture.Image = imageData;
                return BadRequest(ModelState);
            }

            db.Pictures.Add(picture);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = picture.ID }, picture);
        }

        // DELETE: api/Pictures/5
        [ResponseType(typeof(Picture))]
        public IHttpActionResult DeletePicture(int id)
        {
            Picture picture = db.Pictures.Find(id);
            if (picture == null)
            {
                return NotFound();
            }

            db.Pictures.Remove(picture);
            db.SaveChanges();

            return Ok(picture);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PictureExists(int id)
        {
            return db.Pictures.Count(e => e.ID == id) > 0;
        }
    }
}