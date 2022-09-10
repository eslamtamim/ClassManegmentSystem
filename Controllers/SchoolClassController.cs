using ClassManegmentSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClassManegmentSystem.Controllers
{
    public class SchoolClassController : Controller
    {

        private readonly AppDbContext _Context;

        public SchoolClassController(AppDbContext Context)
        {
            _Context = Context;
        }
        private IEnumerable<Class> Class()
        {
            var Class = _Context.classes.Include(e => e.teacher).Include(e => e.student).Include(e => e.student.city).Include(e=>e.Attendees).ToList();
            return Class;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetTeacherClass()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(int Studentid,int Teacherid)
        {
            try
            {
                Class Class = new()
                {
                    StudentId = Studentid,
                    TeacherId = Teacherid,
                };

                Class.student = _Context.Students.Include(e => e.city).FirstOrDefault(e => e.StudentId == Class.StudentId);
                Class.teacher = _Context.Teachers.FirstOrDefault(e => e.TeacherId == Class.TeacherId);
                Class.ClassSubject = Class.teacher.Subject;
                Class.ClassName = Class.teacher.TeacherName + "'s Class in " + Class.student.city.CityName + ", Grade: " + Class.student.StudentGrade + ", Subject: " + Class.ClassSubject;
                Class.ClassNumber = Class.teacher.TeacherId + "-" + Class.student.city.CityId + "-" + Class.student.StudentGrade;
                try
                {
                    _Context.Add(Class);
                    _Context.SaveChanges();
                }
                catch {return RedirectToAction("Error" ,"Home");}

                return RedirectToAction("Table", new { Id = Class.ClassNumber });
            }
            catch { return RedirectToAction("Index", "Students"); }
        }

        public IActionResult Table(string Id)
        {

            var ClassData = Class().Where(e => e.ClassNumber == Id);
            var cc = Class().FirstOrDefault(e => e.ClassNumber == Id);
            var StudentData = ClassData.Select(e => e.student).ToList();

            if (!(StudentData is null))
            {
                //selected just the students of the filter
                ViewBag.Students = _Context.Students.Where(e => e.StudentGrade == cc.student.StudentGrade && e.city.CityName == cc.student.city.CityName).ToList();
                //to take the Teacher data with me, not the best way but it works till i learn the other one
                ViewBag.Teacher = Class().FirstOrDefault(e => e.teacher.TeacherName == cc.teacher.TeacherName).teacher;
                var Attendees = _Context.Attendees.Where(e => e.TeacherId == cc.teacher.TeacherId).ToList();

                return View(Tuple.Create(StudentData, Attendees));
            }
            return RedirectToAction("Index" , "Home");
        }
        [HttpPost]
        public IActionResult Table(int TeacherId , int StudentId , DateTime AttendDate)
        {
            var Class = _Context.classes.FirstOrDefault(e=> e.TeacherId == TeacherId && e.StudentId == StudentId);
            if (!(Class is null)) {
                var Attend = new Attendees()
                {
                    TeacherId = TeacherId,
                    StudentId = StudentId,
                    ClassNumber = Class.ClassNumber,
                    DateOfAttendeens = AttendDate
                };
                Attend.Class = _Context.classes.FirstOrDefault(e => e.TeacherId == TeacherId && e.StudentId == StudentId);
                if (ModelState.IsValid)
                {
                    _Context.Add(Attend);
                    _Context.SaveChanges();
                }
            return RedirectToAction("Table", new { Id = Class.ClassNumber});
            }
            return View("Error", "Home");
        }











    }
}
