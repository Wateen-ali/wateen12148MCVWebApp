using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using wateen12148MCVWebApp.Models;

namespace wateen12148MCVWebApp.Controllers
{
    public class RoomController : Controller
    {
        wateen12148DbContext myDB = new wateen12148DbContext();
        public ActionResult Index()
        {
            List<Room> roomLst = new List<Room>();
            roomLst = (from room in myDB.rooms select room).ToList();
            return View("Index",roomLst);
        }
        [HttpGet]
        public ActionResult InsertRoom()
        {
            return View("InsertRoom");
        }
        [HttpPost]
        public ActionResult InsertRoom(Room room)
        {
            myDB.rooms.Add(room);
            myDB.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetDetails(int id)
        {
            Room obj = new Room();

            obj = (from room in myDB.rooms where room.roomId == id select room).FirstOrDefault();

            return View("RoomDetails",obj);

        }

        public ActionResult DeleteRoom(int id)
        {
            Room obj = new Room();
            obj = (from room in myDB.rooms where room.roomId == id select room).FirstOrDefault();
            myDB.rooms.Remove(obj);
            myDB.SaveChanges();

            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult UpdateRoom(int id)
        {
            var room = myDB.rooms.FirstOrDefault(r => r.roomId == id);
            return View(room);
        }
        [HttpPost]
        public ActionResult UpdateRoom(Room room)
        {
            var obj = myDB.rooms.FirstOrDefault(r => r.roomId == room.roomId);

            obj.roomName = room.roomName;
            obj.roomSize = room.roomSize;
            obj.isAvailable = room.isAvailable;
            obj.location = room.location;

            myDB.SaveChanges();

            return RedirectToAction("Index");
        }



    }
}