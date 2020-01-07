using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TWH.Entities.Models;
using TWH.Repository;
using TWH.Services.Services;

namespace TWH.Services.Managers
{
    public class RoomManager
    {
        public RoomService roomService { get; set; }

        public RoomManager(UnitOfWork unitOfWork)
        {
            roomService = new RoomService(unitOfWork);
        }
        public IEnumerable<Room> GetAll()
        {
            return roomService.GetAll();
        }
        //TODO add test that checks if any room exists of same roomNumber yett.
        public void addRoom(int roomNumber, int maxCats)
        {
            roomService.Any(x => x.Number == roomNumber);
            roomService.Insert(new Room { Number = roomNumber, MaxCats = maxCats });

        }
        //TODO test that editing a room works.
        public void editRoom(int roomNumber, int maxCats)
        {
            //find room based on number, then make attributes same as given.
            //TODO test difference in speed between doing getAll, and sort in here. And getall, get in repo
        }
        public Room getRoom(int roomNumber)
        {
            return roomService.SearchFor(x => x.Number == roomNumber).FirstOrDefault();
        }
    }
}
