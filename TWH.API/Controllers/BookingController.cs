using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TWH.Entities.Models;
using TWH.Services;
namespace TWH.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class BookingController : BaseController
        {
        private BookingManager bookings;

        public BookingController()
        {
            bookings = new BookingManager(unitOfWork);
        }
        [HttpGet]
        [Route("/GetRoomBookings")]
        public IEnumerable<Booking> GetRoomBookings(int roomNumber)
        {
            //get a list of all bookings of which is this room.
            //then return that list.
            var roomBookings = bookings.bookingService.GetAll().Where(x => x.bookedRoom.Number == roomNumber);

              return roomBookings;
        }
        [HttpGet]
        //[Route("/GetBookings")]
        public IEnumerable<Booking> GetBookings()
        {
            //get a list of all bookings of which is this room.
            //then return that list.
            Debug.WriteLine("got here");
            var bookingList = bookings.bookingService.GetAll();
            Debug.WriteLine(bookingList.First().bookedRoom.Id);
            return bookings.bookingService.GetAll();
        }
        [HttpGet]
        [Route("/GetUserBookings")]
        public IEnumerable<Booking> GetUserBookings(string email)
        {
            var roomBookings = bookings.bookingService.GetAll().Where(x => x.customer.Email == email);
                return roomBookings;
        }
        [HttpPost]
        [Route("makebooking")]
        public IActionResult MakeBooking([FromBody] Booking booking)
        {
            Debug.WriteLine("Ok booking");
                return Ok(bookings.MakeBooking(booking));
        }
        [HttpGet]
        [Route("getroomsbydates")]
        public IEnumerable<Room> GetRoomsByDates(string startDate, string endDate, int catAmount)
        {
            Debug.WriteLine("Startdate: "+startDate);
            Debug.WriteLine("Enddate: "+endDate);
            Debug.WriteLine("catAmount:" + catAmount);
            if (startDate != null && endDate != null)
            {
                DateTime startDateD = DateTime.Parse(startDate);
                DateTime endDateD = DateTime.Parse(endDate);
                return bookings.GetRoomsByDates(startDateD, endDateD, catAmount);
            }
            else
            {
                return null;
            }
        }
        [HttpGet]
        [Route("gettodaysbookedrooms")]
        public IEnumerable<Booking> GetTodaysBookedRooms()
        {
            return bookings.GetTodaysBookedRooms();
        }
        [HttpGet]
        [Route("getAllBookedRooms")]
        public IEnumerable<Booking> GetAllBookedRooms()
        {
            return bookings.GetAllBookedRooms();
        }
        [HttpGet]
        [Route("getroomstowatch")]
        [AllowAnonymous]
        public IEnumerable<int> GetRoomsToWatch(string email, string postcode)
        {
            return bookings.GetRoomsToWatch(email, postcode);
        }
    }
}
