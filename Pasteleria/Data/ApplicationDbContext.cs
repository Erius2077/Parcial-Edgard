using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pasteleria.Models;
using Microsoft.EntityFrameworkCore;



namespace Pasteleria.Data
{

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Pasteleria.Models.UserRole> UserRole { get; set; } = default!;
        public DbSet<Pasteleria.Models.Client> Client { get; set; } = default!;
        public DbSet<Pasteleria.Models.Cake> Treatment { get; set; } = default!;
        public DbSet<Pasteleria.Models.CalendaryTime> TreatmentTime { get; set; } = default!;
        public DbSet<Pasteleria.Models.Calendary> Schedule { get; set; } = default!;
        public DbSet<Pasteleria.Models.ReservationStatus> BReservationStatus { get; set; } = default!;
        public DbSet<Pasteleria.Models.Reservation> Booking { get; set; } = default!;
    }
    //public DbSet<Pasteleria.Models.UserRole> UserRole { get; set; } = default!;

}
}