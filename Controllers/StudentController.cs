using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using wateen12148MCVWebApp.Models;

namespace wateen12148MCVWebApp.Controllers
{
    public class StudentController : Controller
    {
        wateen12148DbContext myDB = new wateen12148DbContext();
        public ActionResult Index()
        {
            List<Student> studentLst = new List<Student>();
            studentLst = (from student in myDB.students select student).ToList();
            return View("Index",studentLst);
        }
        [HttpGet]
        public ActionResult InsertStudent()
        {
            return View("InsertStudent");
        }
        [HttpPost]
        public ActionResult InsertStudent(Student student)
        {
            myDB.students.Add(student);
            myDB.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetDetails(int id)
        {
            Student obj = new Student();
            obj = (from data in myDB.students where data.studentId == id select data).FirstOrDefault();
            return View("Details", obj);
        }

        public ActionResult DeleteStudent(int id)
        {
            Student obj = new Student();
            obj = (from data in myDB.students where data.studentId == id select data).FirstOrDefault();
            myDB.students.Remove(obj);
            myDB.SaveChanges();
            return RedirectToAction("Index");


        }
        [HttpGet]
        public ActionResult UpdateStudent(int id)
        {
            var student = myDB.students.FirstOrDefault(s => s.studentId == id);
            return View(student);
        }
        [HttpPost]
        public ActionResult UpdateStudent(Student student)
        {
            var obj = myDB.students.FirstOrDefault(s => s.studentId == student.studentId);

            obj.studentName = student.studentName;
            obj.studentNo = student.studentNo;


            myDB.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}