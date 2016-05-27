using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using FlatRent.Entities;
using FlatRent.Models;
using System.Web;
using System.IO;
using System.Collections.Generic;

namespace FlatRent.Controllers
{
    public class PicturesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        
        public IQueryable<Picture> GetPictures()
        {
            return db.Pictures;
        }

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

        public IHttpActionResult PostPicture(int id)
        {
            if (HttpContext.Current.Request.Files.AllKeys.Any())
            {
                var httpPostedFile = HttpContext.Current.Request.Files["uploadImage"];

                if (httpPostedFile != null)
                {
                    var fileSavePath = Path.Combine(HttpContext.Current.Server.MapPath("~/UploadedFiles"), httpPostedFile.FileName);

                    httpPostedFile.SaveAs(fileSavePath);

                    //Stream stream = httpPostedFile.InputStream;  infinite process to make that

                    //byte[] imageData = new byte[524288]; // 4mb = 4 000 000; 0.5 mb = 524288
                    //while (stream.Read(imageData, 0, 524288) != -1)
                    //{
                    //    ;
                    //}
                    //byte i = imageData[0];

                    Picture pic = new Picture();
                }

            }

            return CreatedAtRoute("DefaultApi", new { id = 1 }, new Picture { ID = 1});
        }
       

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