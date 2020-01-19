using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TWH.Entities.Models;
using TWH.Services.Managers;

namespace TWH.API.Controllers
{
    //[Produces("application/json")]
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class RoomController : BaseController
    {
        private RoomManager roomManager;

        public RoomController()
        {
            roomManager = new RoomManager(unitOfWork);
        }
        [HttpGet]
        [Route("getall")]
        public IActionResult GetRooms()
        {
            return Ok(roomManager.roomService.GetAll().ToList());
        }
        [HttpGet]
        [Route("getall2")]
        public IEnumerable<Room> GetRooms2()
        {
            return roomManager.roomService.GetAll();
        }
        [HttpPost]
        [Route("addRoom")]
        public void addRoom(int roomNumber, int maxCats)
        {
            roomManager.roomService.Insert(new Room { Number = roomNumber, MaxCats = maxCats });
        }
    }
}
