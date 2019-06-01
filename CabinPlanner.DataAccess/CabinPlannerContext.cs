using System.Data.SqlClient;

using CabinPlanner.Model;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CabinPlanner.DataAccess
{
    public class CabinPlannerContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Family> Families { get; set; }
        public DbSet<Cabin> Cabins { get; set; }
        public DbSet<Calendar> Calendars { get; set; }
        public DbSet<PlannedTrip> PlannedTrips { get; set; }
        //public DbSet<Relation> Relations { get; set; }
        public DbSet<CabinUser> CabinUsers { get; set; }
        public DbSet<CalendarTrip> CalendarTrips { get; set; }

        string ConnectionString = "Data Source=Donau.hiof.no;Initial Catalog=denniss;Persist Security Info=True;User ID=denniss;Password=6WVewQKT";

        public CabinPlannerContext(DbContextOptions<CabinPlannerContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CabinUser>()
                .HasKey(sc => new { sc.PersonId, sc.CabinId });
            modelBuilder.Entity<CabinUser>()
                .HasOne(sc => sc.Person)
                .WithMany(s => s.AccessToCabins)
                .HasForeignKey(sc => sc.PersonId);
            modelBuilder.Entity<CabinUser>()
                .HasOne(sc => sc.Cabin)
                .WithMany(c => c.CabinUsers)
                .HasForeignKey(sc => sc.CabinId);

            modelBuilder.Entity<CalendarTrip>()
                .HasKey(sc => new { sc.CalendarId, sc.PlannedTripId });
            modelBuilder.Entity<CalendarTrip>()
                .HasOne(ct => ct.Calendar)
                .WithMany(s => s.PlannedTrips)
                .HasForeignKey(sc => sc.CalendarId);
            modelBuilder.Entity<CalendarTrip>()
                .HasOne(sc => sc.PlannedTrip)
                .WithMany(c => c.TripCalendars)
                .HasForeignKey(sc => sc.PlannedTripId);
        }

        public class CabinPlannerContextFactory : IDesignTimeDbContextFactory<CabinPlannerContext>
        {
            public CabinPlannerContext CreateDbContext(string[] args)
            {
                var connection = "Data Source=Donau.hiof.no;Initial Catalog=denniss;Persist Security Info=True;User ID=denniss;Password=6WVewQKT";

                var optionsBuilder = new DbContextOptionsBuilder<CabinPlannerContext>();
                optionsBuilder.UseSqlServer(connection, x => x.MigrationsAssembly("CabinPlanner.DataAccess"));

                return new CabinPlannerContext(optionsBuilder.Options);
            }
        }


    }


}
