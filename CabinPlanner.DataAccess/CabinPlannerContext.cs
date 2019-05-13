using System.Data.SqlClient;

using CabinPlanner.Model;

using Microsoft.EntityFrameworkCore;

namespace CabinPlanner.DataAccess
{
    public class CabinPlannerContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Family> Families { get; set; }
        public DbSet<Cabin> Cabins { get; set; }
        public DbSet<Calendar> Calendars { get; set; }
        public DbSet<PlannedTrip> PlannedTrips { get; set; }
        public DbSet<Relation> Relations { get; set; }

      //  string ConnectionString = "Data Source=Donau.hiof.no;Initial Catalog=denniss;Persist Security Info=True;User ID=denniss;Password=6WVewQKT";
      //
        public CabinPlannerContext(DbContextOptions<CabinPlannerContext> options) : base(options) { }
      //
      //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
      //{
      //    optionsBuilder.UseSqlServer(@ConnectionString);
      //}
    }
}
