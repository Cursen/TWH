using System;
using System.Collections.Generic;
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
        public IEnumerable<Booking> ListBookingsForCustomer(Guid userID)
        {
            return bookingService.SearchFor(x => x.Id == userID);
        }
        //TODO make customer be customerID instead(so you dont transfer object, but object id??
        public Booking PrepareBookingRequest(Guid roomID, Guid userID, DateTime startDate, DateTime endDate, LinkedList<Cat> cats)
        {
            var room = roomService.GetById(roomID);
            var customer = customerService.GetById(userID);

            var booking = new Booking
            {
                customer = customer,
                bookedRoom = room,
                cats = cats,
                startDate = startDate,
                endDate = endDate,
                bookinDate = DateTime.Now
            };
            return booking;
        }
        //TODO Customer customer is basicly who is logged in it seems in example, cannot be used here as the employee is logged in.
        public Booking MakeBooking(Booking bookingRequest)
        {
            if (bookingService.Any(x => x.bookedRoom.Id == bookingRequest.bookedRoom.Id && x.startDate > bookingRequest.endDate && bookingRequest.startDate > bookingRequest.endDate))
                {
                throw new DataMisalignedException("The room is already booked within this date range");
                }
            else
                {
                bookingService.Insert(bookingRequest);
                bookingService.SaveChanges();
                return bookingRequest;
                }
        }
    }
}
