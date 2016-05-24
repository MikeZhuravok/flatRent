﻿using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
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

        //[ResponseType(typeof(Picture))]
        //public IHttpActionResult PostPicture(/*[FromBody]string name,*/ HttpPostedFileBase uploadImage)
        //{

        //    Picture picture = new Picture()
        //    {
        //        Name = /*name*/"random name"
        //    };
        //    if (!ModelState.IsValid)
        //    {
        //        byte[] imageData = null;
        //        using (var binaryReader = new BinaryReader(uploadImage.InputStream))
        //        {
        //            imageData = binaryReader.ReadBytes(uploadImage.ContentLength);
        //        }
        //        picture.Image = imageData;
        //        return BadRequest(ModelState);
        //    }

        //    db.Pictures.Add(picture);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = picture.ID }, picture);
        //}

        public IHttpActionResult PostPicture(/*[FromBody]string name,*/ HttpPostedFileBase uploadImage)
        {
            if (uploadImage != null)
            {
                string pic = System.IO.Path.GetFileName(uploadImage.FileName);
                string path = System.IO.Path.Combine(
                                       System.Web.HttpContext.Current.Server.MapPath("~/images/profile"), pic);
                // file is uploaded
                uploadImage.SaveAs(path);

                // save the image path path to the database or you can send image 
                // directly to database
                // in-case if you want to store byte[] ie. for DB
                using (MemoryStream ms = new MemoryStream())
                {
                    uploadImage.InputStream.CopyTo(ms);
                    byte[] array = ms.GetBuffer();
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = 1 }, new Picture { ID = 1});
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