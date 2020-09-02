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
        //TODO Return error
        public void addRoom(Room room)
        {
            if(!roomService.Any(x => x.Number == room.Number))
            {
                roomService.Insert(new Room { Number = room.Number, MaxCats = room.MaxCats });
            }
        }
        //TODO test that editing a room works.
        public void editRoom(Room room)
        {
            //find room based on number, then make attributes same as given.
            if(room != null)
            {
                var foundRoom = roomService.GetById(room.Id);
                if(foundRoom == null)
                {
                    //TODO consider returning information that the edit ended up doing nothing.
                    return;
                }
                foundRoom = room;
                roomService.SaveChanges();
            }
        }
        public Room getRoom(int roomNumber)
        {
            return roomService.SearchFor(x => x.Number == roomNumber).FirstOrDefault();
        }
    }
}
