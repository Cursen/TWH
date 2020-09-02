using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Text;
using TWH.Entities.Models;
using TWH.Repository;
using TWH.Services.Managers;

namespace TWH.UnitTests
{
    [TestClass]
    public class UnitTestRoom
    {
        public void printRoom(Room room)
        {
            Debug.WriteLine(room);
            Debug.WriteLine($"Room: ID: {room.Id}, Number: {room.Number}, maxCats: {room.MaxCats}");
        }
        
        [TestMethod]
        //Ensure that a error is thrown when a unique room is attempted to be added. As it currently stands this shuts down the server,
        //Should implement a error class, and functinality of which prevents this.
        public void TestRoomNumberUnique()
        {

                //Arrange
                var unitOfWork = new UnitOfWork();
            var manager = new RoomManager(unitOfWork);
            var room = new Room{ MaxCats=2, Number=15};
            var room2 = new Room { MaxCats = 3, Number = 15 };

            //Act
            manager.addRoom(room);
            printRoom(room);
            try
            {
                manager.addRoom(room2);
                Assert.Fail();
            }
            catch (Exception) { }
            //Assert
           
        }
        [TestMethod]
        public void TestRoomEdit()
        {
            //Arrange
            var unitOfWork = new UnitOfWork();
            var manager = new RoomManager(unitOfWork);
            var room = new Room { MaxCats = 2, Number = 115 };

            //Act
            manager.addRoom(room);
            printRoom(room);
            var storedRoom = manager.getRoom(room.Number);
            storedRoom.MaxCats = 1;
            manager.editRoom(storedRoom);
            var gottenEditedRoom = manager.getRoom(storedRoom.Number);
            //Assert
            printRoom(storedRoom);
            printRoom(gottenEditedRoom);
            Assert.AreEqual(storedRoom.MaxCats, gottenEditedRoom.MaxCats);
        }
        [TestMethod]
        public void TestUnexistingRoomEdit()
        {
            //Arrange
            var unitOfWork = new UnitOfWork();
            var manager = new RoomManager(unitOfWork);
            var room = new Room { MaxCats = 2, Number = 120 };

            //Act
            printRoom(room);
            manager.editRoom(room);
            //Assert
            Assert.IsNull(manager.getRoom(room.Number));
        }
    }
}
