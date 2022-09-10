using ClassManegmentSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NuGet.Protocol.Plugins;
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
            var Classes = new List<Class>();
            return View(Tuple.Create(Class(), Classes));


        }
        [HttpPost]
        public IActionResult Index(string TeacherName)
        {
            var Classes = Class().Where(e=> TeacherName == e.teacher.TeacherName).DistinctBy(e=>e.ClassNumber).ToList();
           

            return View(Tuple.Create(Class(),Classes)); 
        }


        public IActionResult Register()
        {
            return View();
        }
       
       

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}