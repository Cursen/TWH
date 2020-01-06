
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using TWH.Entities.Models;

namespace TWH.Entities
{
    //TODO make sure it works as entityframework underneath, and isn't just 
    public class DataContext : DbContext
    {
        public static DataContext Create()
        {
            return new DataContext();
        }
        public DataContext() : base("MyContextDB")
        {
            Database.SetInitializer<DataContext>(new DBInitializer<DataContext>());
        }
        public DbSet<Cat> Cats { get; set; }
        public DbSet<catImage> Customers { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Room> Rooms { get; set; }
        private class DBInitializer<T> : CreateDatabaseIfNotExists<DataContext>
        {
            
            protected override void Seed(DataContext context)
            {
                IList<Room> rooms = new List<Room>();

                rooms.Add(new Room { Number = 2, MaxCats = 3});
                foreach (Room room in rooms)
                {
                    context.Rooms.Add(room);  
                }
                base.Seed(context);
            }
        }
    }
}
