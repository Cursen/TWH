using Microsoft.VisualBasic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Linq;
using TWH.Entities;
using TWH.Entities.Models;
using TWH.Repository;
using TWH.Services;
using TWH.Services.Managers;
using TWH.Services.Services;

namespace TWH.UnitTests
{
    [TestClass]
    public class UnitTestsBooking
    {
        //for quick debugging, by checking actual state of rooms.
        public void printRooms(IEnumerable<Room> rooms)
        {
            Debug.WriteLine("Room print:");
            foreach (var room in rooms)
            {
                Debug.WriteLine(room.Number);
            }
        }
        //for quick debugging, by checking actual state of bookings.
        public void printBookings(IEnumerable<Booking> bookings)
        {
            Debug.WriteLine("booking print:");
            foreach (var book in bookings)
            {
                Debug.WriteLine(book.startDate);
            }
        }
        [TestMethod]
        public void DateFunctionOneOverlap()
        {
            //This test will not work if the Seed data is changed
            //Arrange
            var unitOfWork = new UnitOfWork();
            var manager = new BookingManager(unitOfWork);
            var roomManager = new RoomManager(unitOfWork);
            var rooms = roomManager.GetAll();
            rooms = rooms.Skip(1);
            var bookings = manager.GetAllBookedRooms();
            printBookings(bookings);
            var start = DateTime.Now;
            var end = DateTime.Now.AddDays(4);
            //Act
            Debug.WriteLine($"DateTimes, Start:{start}, End{end}");
            var actualRooms = manager.GetRoomsByDates(start, end, 2);
            //Assert
            //Test if we do not find the room booked now
            printRooms(rooms);
            printRooms(actualRooms);
            Assert.AreEqual(rooms.Count(), actualRooms.Count());
        }
        [TestMethod]
        public void DateFucntionTwoOverlap()
        {
            //Arrange
            var unitOfWork = new UnitOfWork();
            var manager = new BookingManager(unitOfWork);
            var roomManager = new RoomManager(unitOfWork);
            var rooms = roomManager.GetAll();
            rooms = rooms.Skip(2);
            var bookings = manager.GetAllBookedRooms();
            printBookings(bookings);
            var start = DateTime.Now;
            var end = DateTime.Now.AddDays(15);
            //Act
            var actualRooms = manager.GetRoomsByDates(start, end, 2);
            //Assert
            Debug.WriteLine($"DateTimes, Start:{start}, End{end}", start, end);
            //Test if we do not find neiter booked rooms, because they both overlap
            printRooms(rooms);
            printRooms(actualRooms);
            Assert.AreEqual(rooms.Count(), actualRooms.Count());
        }
        [TestMethod]
        public void TestWhoMadeBooking()
        {

        }
        [TestMethod]
        public void TestWhoGotAnyBooking()
        {

        }
        [TestMethod]
        public void TestWhoDeletedBooking()
        {

        }
        [TestMethod]
        public void TestTodaysBookedROoms()
        {

        }
        [TestMethod]
        public void TestGetRoomsToWatch()
        {

        }
        [TestMethod]
        public void TestMakeBookingSuccesfull()
        {

        }
        [TestMethod]
        public void TestMakeBookingOverlap()
        {

        }
        [TestMethod]
        public void TestMakeBookingOccupied()
        {

        }
        [TestMethod]
        public void TestGetBookingsForCustomer()
        {

        }
    }
}
