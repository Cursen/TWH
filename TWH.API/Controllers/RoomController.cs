using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TWH.Entities.Models;
using TWH.Services.Managers;

namespace TWH.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoomController : BaseController
    {
        private RoomManager roomManager;

        public RoomController()
        {
            roomManager = new RoomManager(unitOfWork);
        }
        [HttpGet]
        public IEnumerable<Room> GetRooms()
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
