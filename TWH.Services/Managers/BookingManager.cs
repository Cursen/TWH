using Itenso.TimePeriod;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using TWH.Entities.Models;
using TWH.Repository;
using TWH.Services.Services;

namespace TWH.Services
{
    public class BookingManager
    {
        public RoomService roomService { get; set; }
        public CatService catService { get; set; }
        public BookingService bookingService { get; set; }
        public CustomerService customerService { get; set; }

        public BookingManager(UnitOfWork unitOfWork)
        {
            roomService = new RoomService(unitOfWork);
            catService = new CatService(unitOfWork);
            customerService = new CustomerService(unitOfWork);
            bookingService = new BookingService(unitOfWork);
        }
        public IEnumerable<Booking> ListBookingsForCustomer(string email)
        {
            return bookingService.SearchFor(x => x.customer.Email == email);
        }
        public Booking MakeBooking(Booking bookingRequest)
        {
            Debug.WriteLine("insert booking method called");
            if (bookingService.Any(x => x.bookedRoom.Id == bookingRequest.bookedRoom.Id && x.startDate > bookingRequest.endDate && bookingRequest.startDate > x.endDate))
                {
                throw new DataMisalignedException("The room is already booked within this date range");
                }
            else
                {
                bookingRequest.bookingDate = DateTime.Now;
                if (bookingRequest.startDate.HasValue)
                {
                    Debug.WriteLine("Attempted to inser booking");
                }
                Debug.WriteLine("Attempted to inser booking");
                Debug.WriteLine("startDate: " + bookingRequest.bookingDate);
                Debug.WriteLine("startDate: "+ bookingRequest.startDate);
                Debug.WriteLine("endDate: " + bookingRequest.endDate);

                bookingService.Insert(bookingRequest);
                bookingService.SaveChanges();
                return bookingRequest;
                }
        }
        public IEnumerable<int> GetRoomsToWatch(string email, string postcode)
        {
            var bookings = bookingService.SearchFor(x => x.customer.Email == email && x.customer.postCode == postcode).ToList();
            List<int> OkRooms = new List<int>();
            foreach(var booking in bookings)
            {
                OkRooms.Add(booking.bookedRoom.Number);
            }
            return OkRooms;
        }
        //Note that it is currently expecting startDate > endDate
        //Used to get all rooms available within a range of dates.
        public IEnumerable<Room> GetRoomsByDates(DateTime startDate, DateTime endDate, int catAmount)
        {
            //TODO utilise Exception types for the layers by wrapping them, look at 168 of adaptive code to solve this. 
            //Additionally it needs a test.
            if (startDate > endDate)
            {
                throw new ArgumentException("startDate Cannot be Bigger than Endate.");
            }
            var rooms = roomService.GetAll().ToList();
            List<Room> OkRooms = new List<Room>();
            var bookings = bookingService.SearchFor(x => x.startDate <= endDate && startDate <= x.endDate);
            Debug.WriteLine($"bookings found: {bookings.Count()}");
            List<Room> bookedRooms = new List<Room>();
            foreach(var booking in bookings)
            {
                if(!bookedRooms.Any(x => x.Number == booking.bookedRoom.Number))
                {
                    bookedRooms.Add(booking.bookedRoom);
                }
            }
            var okRooms = rooms.Except(bookedRooms);
            return okRooms;
        }

        public IEnumerable<Booking> GetAllBookedRooms()
        {
            return bookingService.GetAll();
        }
        public IEnumerable<Booking> GetTodaysBookedRooms()
        {
            var rooms = roomService.GetAll().ToList();
            var bookedRooms = bookingService.SearchFor(x => x.startDate < DateTime.Now && x.endDate > DateTime.Now).ToList();
            foreach(var room in rooms)
            {
                if(!bookedRooms.Any(x=> x.bookedRoom.Number == room.Number))
                {
                    var booking = new Booking();
                    booking.bookedRoom = room;
                    bookedRooms.Add(booking);
                }
            }
            bookedRooms.OrderBy(x => x.bookedRoom.Number);
            return bookedRooms;
        }
    }
}
