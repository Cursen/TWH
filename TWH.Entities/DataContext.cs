
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using TWH.Entities.Models;

namespace TWH.Entities
{
    //TODO change this into rect auth api instead.
    public class DataContext : DbContext
    {
        public static DataContext Create()
        {
            return new DataContext();
        }
        public DataContext() : base("MyContextDB")
        {
            Database.SetInitializer<DataContext>(new UniDBInitializer<DataContext>());
        }
        public DbSet<Cat> Cats { get; set; }
        public DbSet<catImage> Customers { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<User> Users { get; set; }
        private class UniDBInitializer<T> : CreateDatabaseIfNotExists<DataContext>
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
