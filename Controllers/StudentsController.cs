﻿using ClassManegmentSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClassManegmentSystem.Controllers
{
    public class StudentsController : Controller
    {
        private readonly AppDbContext _Context;

        public StudentsController(AppDbContext Context)
        {
            _Context = Context;
        }
        private IEnumerable<Student> students()
        {
            return _Context.Students.Include(m=> m.city);
        }

        public IActionResult Index()
        {

            return View(students());
        }
        [HttpGet]
        public IActionResult Create()
        {
           ViewBag.Cities = _Context.cities.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {

            if (ModelState.IsValid)
            {
                _Context.Students.Add(student);
                _Context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student);
        }

        public IActionResult Edit(string id)
        {
     
            var student = students().FirstOrDefault(s => s.StudentId == id);
            ViewBag.Cities = _Context.cities.ToList();
            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {

            if (ModelState.IsValid)
            {
                _Context.Students.Update(student);
                student.CreationDate = DateTime.Now;
                _Context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student);
        }

        [HttpGet]
        public IActionResult Info(string id)
        {
            var student = students().FirstOrDefault(s => s.StudentId == id);
            ViewBag.Cities = _Context.cities.ToList();
            return View(student);
        }

        [HttpGet]
        public IActionResult Delete(string id)
        {
            var student = students().FirstOrDefault(s => s.StudentId == id);
            if (ModelState.IsValid)
            {
                _Context.Students.Remove(student);
                _Context.SaveChanges();
                return Ok();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}