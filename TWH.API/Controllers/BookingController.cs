using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using TWH.Entities.Models;
using TWH.Services;
using AuthorizeAttribute = System.Web.Http.AuthorizeAttribute;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;

namespace TWH.API.Controllers
{
    [Authorize]
    public class BookingController : BaseController
        {
        private BookingManager bookings;

        public BookingController()
        {
            bookings = new BookingManager(unitOfWork);
        }
        public IHttpActionResult GetRoomBookings(int roomNumber)
        {
            //get a list of all bookings of which is this room.
            //then return that list.
            var roomBookings = bookings.bookingService.GetAll().Where(x => x.bookedRoom.Number == roomNumber);
            if (roomBookings == null)
            {
              return NotFound();
            }
            else
            {
              return Ok(roomBookings);
            }
        }
        public IHttpActionResult GetUserBookings(string email)
        {
            var roomBookings = bookings.bookingService.GetAll().Where(x => x.customer.Email == email);
            if(roomBookings == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(roomBookings);
            }
        }
        public IHttpActionResult MakeBooking(int roomNumber, DateTime startDate, DateTime endDate, string userEmail, LinkedList<Cat> cats)
        {
            //get list of bookings of given room. Then check if it works
            var roomBookings = GetRoomBookings(roomNumber);
            if(roomBookings == null)
            {
                return NotFound();
            }
            else
            {
                Guid roomID = bookings.roomService.SearchFor(x => x.Number == roomNumber).FirstOrDefault().Id;
                Guid userID = bookings.customerService.SearchFor(x => x.Email == userEmail).FirstOrDefault().Id;
                return Ok(bookings.MakeBooking(bookings.PrepareBookingRequest(roomID, userID, startDate, endDate, cats)));
                }
            }
    }
    }
}
