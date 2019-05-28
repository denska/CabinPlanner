using CabinPlanner.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;

namespace CabinPlanner.MaintainDatabase.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Entertain me!");

            var connection = @"Data Source=Donau.hiof.no;Initial Catalog=denniss;Persist Security Info=True;User ID=denniss;Password=6WVewQKT";
            var optionsBuilder = new DbContextOptionsBuilder<CabinPlannerContext>();
            optionsBuilder.UseSqlServer(connection);

            {
                using (var db = new CabinPlannerContext(optionsBuilder.Options))
                {
                    //db.Actors.Add(new Actor { FirstName = "Hugh", LastName = "Jackman", DateOfBirth = new DateTime(1968, 10, 12) });
                    //var count = db.SaveChanges();
                    //Console.WriteLine("{0} records saved to database", count);

                    Console.WriteLine();
                    Console.WriteLine("All actors in database:");
                    foreach (var person in db.People)
                    {
                        Console.WriteLine(" - {0}", person.ToString());
                    }
                }
            }
        }
    }
}
