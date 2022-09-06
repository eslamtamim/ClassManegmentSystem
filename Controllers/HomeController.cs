using ClassManegmentSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            Class Class = new()
            {
                StudentId = int.Parse(Request.Form["Studentid"]),
                TeacherId = int.Parse(Request.Form["Teacherid"]),
            };
            if(ModelState.IsValid)
                _Context.Add(Class);
            try
            {
                _Context.SaveChanges();
            }
            catch
            {
                _Context.Remove(Class);
             
            }
            return RedirectToAction("Index");
        }
        public IActionResult Table()
        {
            ViewBag.Teacher = Request.Form["Teacher"];
            ViewBag.Grade = Request.Form["Grade"];
            ViewBag.City = Request.Form["City"];

            var data = Class().Where(e => e.teacher.TeacherName == Request.Form["Teacher"] &&
            e.student.StudentGrade == Request.Form["Grade"] && e.student.city.CityName == Request.Form["City"]).ToList();
            return View(data);
        }























        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}