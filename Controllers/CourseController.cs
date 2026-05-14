using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using wateen12148MCVWebApp.Models;

namespace wateen12148MCVWebApp.Controllers
{
    
    
    public class CourseController : Controller
    {
        wateen12148DbContext myDB = new wateen12148DbContext();
        public ActionResult Index()
        {
            List<Course>courseLst = new List<Course>();
            courseLst = (from obj in myDB.courses select obj).ToList();

            return View("Index",courseLst);
        }

        public ActionResult GetCourse(int id)
        {
            Course obj = new Course();

            obj = (from xyz in myDB.courses where xyz.courseId==id select xyz).FirstOrDefault();

            return View("Details",obj);

        }

        [HttpGet]
        public ActionResult InsertCourse()
        {
            return View("InsertCourse");
        }
        [HttpPost]
        public ActionResult InsertCourse(Course course)
        {
            myDB.courses.Add(course);
            myDB.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCourse(int id)
        {
            Course obj = new Course();
            obj = (from course in myDB.courses where course.courseId == id select course).FirstOrDefault();
            myDB.courses.Remove(obj);
            myDB.SaveChanges();

            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult UpdateCourse(int id)
        {
            var course = myDB.courses.FirstOrDefault(c => c.courseId == id);
            return View(course);
        }
        [HttpPost]
        public ActionResult UpdateCourse(Course course)
        {
            var obj = myDB.courses.FirstOrDefault(c => c.courseId == course.courseId);

            obj.courseName = course.courseName;
           
            obj.isAvailable = course.isAvailable;
            

            myDB.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}