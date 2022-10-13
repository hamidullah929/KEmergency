using Kemergency.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Kemergency.ViewModels;
using Kemergency.Areas.FireTrackK.Models;

namespace Kemergency.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
      

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Hservice> Hservices { get; set; }
       
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<FireTrack> FireTracks { get; set; }
        public DbSet<FireTrackBooking> FireTrackBookings { get; set; }
        public DbSet<Myusers> Customers { get; set; }
        public DbSet<Rental> Rentals { get; set; }
       
        
        public DbSet<Kemergency.ViewModels.EditBookingViewModel> EditBookingViewModel { get; set; }

       



    }
}
