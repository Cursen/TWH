﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TWH.Entities.Models;
using TWH.Services;

namespace TWH.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : BaseController
    {
        private BookingManager bookings;

        public BookingController()
        {
            bookings = new BookingManager(unitOfWork);
        }
        [HttpGet]
        [Route("b")]
        public IEnumerable<Booking> GetRoomBookings(int roomNumber)
        {
            //get a list of all bookings of which is this room.
            //then return that list.
            var roomBookings = bookings.bookingService.GetAll().Where(x => x.bookedRoom.Number == roomNumber);

            return roomBookings;
        }
        [HttpGet]
        [Route("k")]
        public IEnumerable<Booking> GetUserBookings(string email)
        {
            var roomBookings = bookings.bookingService.GetAll().Where(x => x.customer.Email == email);
            return roomBookings;
        }
        [HttpGet]
        [Route("z")]
        public Booking MakeBooking(int roomNumber, DateTime startDate, DateTime endDate, string userEmail, LinkedList<Cat> cats)
        {
            //get list of bookings of given room. Then check if it works
            var roomBookings = GetRoomBookings(roomNumber);
            Guid roomID = bookings.roomService.SearchFor(x => x.Number == roomNumber).FirstOrDefault().Id;
            Guid userID = bookings.customerService.SearchFor(x => x.Email == userEmail).FirstOrDefault().Id;
            return bookings.MakeBooking(bookings.PrepareBookingRequest(roomID, userID, startDate, endDate, cats));
        }
        [HttpGet]
        public IEnumerable<Room> GetRooms()
        {
            return bookings.roomService.GetAll();
        }
        [HttpPost]
        [Route("addRoom")]
        [Authorize]
        public void addRoom(int roomNumber, int maxCats)
        {
            bookings.roomService.Insert(new Room { Number = roomNumber, MaxCats = maxCats });
        }
    }
}