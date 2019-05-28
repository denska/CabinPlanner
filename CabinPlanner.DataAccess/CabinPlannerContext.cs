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
        public DbSet<CabinUser> CabinsUsers { get; set; }

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
        }

        public class EntertainmentContextFactory : IDesignTimeDbContextFactory<CabinPlannerContext>
        {
            public CabinPlannerContext CreateDbContext(string[] args)
            {
                var connection = "Data Source=Donau.hiof.no;Initial Catalog=denniss;Persist Security Info=True;User ID=denniss;Password=6WVewQKT";

                var optionsBuilder = new DbContextOptionsBuilder<CabinPlannerContext>();
                optionsBuilder.UseSqlServer(connection, x => x.MigrationsAssembly("Entertainment.MaintainDatabase.ConsoleApp"));

                return new CabinPlannerContext(optionsBuilder.Options);
            }
        }


    }


}
