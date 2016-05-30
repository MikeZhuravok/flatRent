using FlatRent.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FlatRent.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Facility> Facilities { get; set; }
        public DbSet<Flat> Flats { get; set; }
        public DbSet<Picture> Pictures {get;set;}
        public DbSet<FacilityInFlat> FacilityInFlats { set; get; }
    }
}