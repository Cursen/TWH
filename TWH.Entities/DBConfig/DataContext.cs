
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
        //I would use The entitiy framework core version of initialisation in the future, using the options : base(options) route instead. This would require the way seeding etc are done.
        public DataContext() : base("MyContextDB")
        {
            Database.SetInitializer<DataContext>(new DBInitializer<DataContext>());
        }
        public DbSet<Cat> Cats { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Room> Rooms { get; set; }

        //this section determines additional unique identifiers beyond just ID in some models.
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasIndex(x => x.Email).IsUnique();
            modelBuilder.Entity<Room>().HasIndex(x => x.Number).IsUnique();
        }
        //Used to seed the database, DropCreateDataseAlways needs to be changed in a production environment, orelse a restart will delete all data.
        private class DBInitializer<T> : DropCreateDatabaseAlways<DataContext>
        {
            
            protected override void Seed(DataContext context)
            {
                IList<Room> rooms = new List<Room>();
                IList<Customer> customers = new List<Customer>();
                IList<Cat> cats = new List<Cat>();
                IList<Booking> bookings = new List<Booking>();
                IList<Cat> cats2 = new List<Cat>();
                int count = 1;
                while(count <= 10) {
                    rooms.Add(new Room { Number = count, MaxCats = 3});
                    count++;
                };
                cats.Add(new Cat { ChipID = "11111111111", Name = "Mittens", Desc = "Grumpy, old, Black" });
                cats.Add(new Cat { ChipID = "33333333333", Name = "Mittens", Desc = "Grumpy, old, Black" });
                cats2.Add(new Cat { ChipID = "44444444444", Name = "Mittens", Desc = "Grumpy, old, Black" });
                customers.Add(new Customer { Email = "bob@123.com", Firstname = "bob", Lastname = "Marley", PhoneNumber = "92633181", Address = "123fakestreet", Cats = cats, postCode = "4325" });
                bookings.Add(new Booking { bookedRoom = rooms[0], customer = customers[0], cats = cats, startDate = DateTime.Now, endDate = DateTime.Now.AddDays(7), bookingDate = DateTime.Now });
                cats.Add(new Cat { ChipID = "2222222222", Name = "Bobbins", Desc = "Happy, White, playfull" });
                customers.Add(new Customer { Email = "alice@1234.com", Firstname = "alice", Lastname = "dahl", PhoneNumber = "92633181", Address = "123fakestreet", Cats = cats2, postCode = "4352" });
                bookings.Add(new Booking { bookedRoom = rooms[1], customer = customers[1], cats = cats2, startDate = DateTime.Now.AddDays(5), endDate = DateTime.Now.AddDays(7), bookingDate = DateTime.Now });
                context.Rooms.AddRange(rooms);  
                context.Cats.AddRange(cats);
                context.Customers.AddRange(customers);
                context.Bookings.AddRange(bookings);
                base.Seed(context);
            }
        }
    }
}
