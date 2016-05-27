using Microsoft.AspNet.Identity.EntityFramework;
using FlatRent.Models;

namespace FlatRent.Web.Models
{


    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<FlatRent.Entities.Facility> Facilities { get; set; }

        public System.Data.Entity.DbSet<FlatRent.Entities.Picture> Pictures { get; set; }

        public System.Data.Entity.DbSet<FlatRent.Entities.Flat> Flats { get; set; }
    }
}