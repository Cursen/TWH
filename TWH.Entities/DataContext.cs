using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

        public DbSet<Cat> Cats { get; set; }
        public DbSet<CatImage> Customers { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Room> Rooms { get; set; }
    }
}
