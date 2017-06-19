using CarVehicle.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CarVehicle.Reposetory
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {

        }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public  DbSet<SaveVehicle> SaveVehicles { get; set; }
        public  DbSet<SheduleVehicle> SheduleVehicles { get; set; }
        public  DbSet<Shift> Shifts { get; set; }
    }
}