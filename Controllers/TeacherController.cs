using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using wateen12148MCVWebApp.Models;

namespace wateen12148MCVWebApp.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        wateen12148DbContext myDB = new wateen12148DbContext();
        public ActionResult Index()
        {
            List<Teacher> teacherLst = new List<Teacher>();
            teacherLst = (from teacher in myDB.teachers select teacher).ToList();
            return View("Index",teacherLst);
        }
        [HttpGet]
        public ActionResult InsertTeacher()
        {
            return View("InsertTeacher");
        }
        [HttpPost]
        public ActionResult InsertTeacher(Teacher teacher)
        {
            myDB.teachers.Add(teacher);
            myDB.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetDetails(int id)
        {
            Teacher obj = new Teacher();
            obj = (from data in myDB.teachers where data.teacherId == id select data).FirstOrDefault();
            return View("Details",obj);
        }

        public ActionResult DeleteTeacher(int id)
        {
            Teacher obj = new Teacher();
            obj= (from data in myDB.teachers where data.teacherId == id select data).FirstOrDefault();
            myDB.teachers.Remove(obj);
            myDB.SaveChanges();
            return RedirectToAction("Index");
           

        }
        [HttpGet]
        public ActionResult UpdateTeacher(int id)
        {
            var teacher = myDB.teachers.FirstOrDefault(t => t.teacherId == id);
            return View(teacher);
        }
        [HttpPost]
        public ActionResult UpdateTeacher(Teacher teacher)
        {
            var obj = myDB.teachers.FirstOrDefault(t => t.teacherId == teacher.teacherId);

            obj.teacherName = teacher.teacherName;
            obj.teacherNo = teacher.teacherNo;
            

            myDB.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}