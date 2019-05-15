using System;
using System.Collections.Generic;
using System.Text;

namespace CabinPlanner.Model
{
    public class MyTestData
    {
        private static MyTestData myTestData = null;

        public List<Person> People { get; set; }
        public List<Cabin> Cabins { get; set; }
        public List<Family> Families { get; set; }
        public List<Calendar> Calendars { get; set; }

        private MyTestData()
        {
            // Prevent outside instantiation
        }

        public static MyTestData GetInstance()
        {
            if (myTestData == null)
            {
                myTestData = new MyTestData();

                myTestData.People = new List<Person>()
                {
                    new Person()
                    {
                        PersonId = 1,
                        FirstName = "Dennis",
                        LastName = "Skants",
                        Email = "dennis",
                        Password = "123",
                        DateOfBirth = new DateTime(2017, 1, 18)
                    },
                    new Person()
                    {
                        PersonId = 2,
                        FirstName = "Tom",
                        LastName = "Skants",
                        Email = "tom",
                        Password = "123",
                        DateOfBirth = new DateTime(1965, 1, 18)
                    },
                    new Person()
                    {
                        PersonId = 3,
                        FirstName = "Hamme",
                        LastName = "Teien",
                        Email = "hanne",
                        Password = "123",
                        DateOfBirth = new DateTime(2010, 1, 18)
                    }

                };

                myTestData.Cabins = new List<Cabin>()
                {
                    new Cabin()
                    {
                        CabinName = "Bogen",
                        CabinOwner = myTestData.People[0],
                        CabinUsers = myTestData.People,
                        Calendar = new Calendar()
                        {
                            PlannedTrips = new List<PlannedTrip>()
                            {
                                new PlannedTrip()
                                {
                                    FromDate = new DateTime(2010, 1, 18),
                                    ToDate = new DateTime(2010, 2, 18),
                                    Comment = "Dennis Skitur med brødre"
                                },
                                new PlannedTrip()
                                {
                                    FromDate = new DateTime(2012, 3, 18),
                                    ToDate = new DateTime(2012, 4, 18),
                                    Comment = "Cassandra påskeferie"
                                }

                            }
                        }
                    },
                    new Cabin()
                    {
                        CabinName = "Skredderstolen",
                        CabinOwner = myTestData.People[1],
                        CabinUsers = myTestData.People,
                        Calendar = new Calendar()
                        {
                            PlannedTrips = new List<PlannedTrip>()
                            {
                                new PlannedTrip()
                                {
                                    FromDate = new DateTime(2030, 1, 18),
                                    ToDate = new DateTime(2010, 2, 18),
                                    Comment = "Fisketur"
                                },
                                new PlannedTrip()
                                {
                                    FromDate = new DateTime(2012, 3, 18),
                                    ToDate = new DateTime(2012, 4, 18),
                                    Comment = "Jakt"
                                }

                            }
                        }
                    }
                };
            }

            return myTestData;
        }


    }
}
