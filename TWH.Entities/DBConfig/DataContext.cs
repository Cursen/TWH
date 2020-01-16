
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
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Room> Rooms { get; set; }
        private class DBInitializer<T> : DropCreateDatabaseAlways<DataContext>
        {
            
            protected override void Seed(DataContext context)
            {
                IList<Room> rooms = new List<Room>();
                IList<Customer> customers = new List<Customer>();
                IList<Cat> cats = new List<Cat>();
                IList<Booking> bookings = new List<Booking>();

                rooms.Add(new Room { Number = 2, MaxCats = 3});
                cats.Add(new Cat { ChipID = "11111111111", Name = "Mittens", Desc = "Grumpy, old, Black" });
                customers.Add(new Customer { Email = "bob@123.com", Firstname = "bob", Lastname = "Marley", PhoneNumber = "92633181", Address = "123fakestreet", Cats = cats });
                bookings.Add(new Booking { bookedRoom = rooms[0], customer = customers[0], cats = cats, startDate = DateTime.Now, endDate = DateTime.Now.AddDays(7), bookingDate = DateTime.Now });
                    context.Rooms.AddRange(rooms);  
                    context.Cats.AddRange(cats);
                    context.Customers.AddRange(customers);
                    context.Bookings.AddRange(bookings);


                base.Seed(context);
            }
        }
    }
}
