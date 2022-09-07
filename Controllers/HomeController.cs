using ClassManegmentSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Diagnostics;

namespace ClassManegmentSystem.Controllers
{
    public class HomeController : Controller
    {

        private readonly AppDbContext _Context;

        public HomeController(AppDbContext Context)
        {
            _Context = Context;
        }

        private IEnumerable<Class> Class()
        {
            var Class = _Context.classes.Include(e => e.teacher).Include(e => e.student).Include(e => e.student.city).ToList();
            return Class;
        }

        public IActionResult Index()
        {
            return View(Class());
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create()
        {
            try
            {
            Class Class = new()
            {
             
                StudentId = int.Parse(Request.Form["Studentid"]),
                TeacherId = int.Parse(Request.Form["Teacherid"]),
            };
            try
            {
            _Context.Add(Class);
            _Context.SaveChanges();
            }
            catch
            {
                return RedirectToAction("Error");
            }

            } 
            catch
            {
                return RedirectToAction("Index", "Students");
            } 
            return RedirectToAction("Index"); 

        }

        public IActionResult Table(string TeacherName , string CityName, string Grade)
        {   
            
            var StudentData = Class().Where(e => e.teacher.TeacherName == TeacherName &&
                                          e.student.StudentGrade == Grade && 
                                          e.student.city.CityName == CityName).Select(e=> e.student).ToList();
           
            if(!(TeacherName is null|| CityName is null || Grade is null))
            {
            //selected just the students of the filter
            ViewBag.Students = _Context.Students.Where(e => Convert.ToString(e.StudentGrade) == Grade && Convert.ToString(e.city.CityName) == Convert.ToString(Request.Form["City"])).ToList();

            //to take the Teacher data with me, not the best way but it works till i learn the other one
            ViewBag.Teacher = Class().FirstOrDefault(e => e.teacher.TeacherName == TeacherName).teacher;

            return View(StudentData);
            }

            return RedirectToAction("Index");


        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}