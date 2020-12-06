using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Claims;  
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

using Microsoft.Extensions.Logging;
using FridaSchoolWeb.Models;

namespace FridaSchoolWeb.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;
        FridaSchool db;
        Teacher teacher {get; set;}

        public AdminController(ILogger<AdminController> logger, FridaSchool injectedContext)
        {
            _logger = logger;
            db = injectedContext;
        }

        public IActionResult Index(string message)
        {
            IQueryable<Teacher> teachers = db.Teachers;
            return View(teachers);
        }
        public IActionResult Create(){
            return View();
        }

        [HttpPost]
        public IActionResult Create(string names, string middleName, string lastName, string birthDate, string genre, string password){
            Teacher teacher = new Teacher{
                Names = names,
                MiddleName = middleName,
                LastName = lastName,
                BirthDate = DateTime.Parse(birthDate),
                Gender = genre[0],
                Password = password
            };
            db.Teachers.Add(teacher);
            db.SaveChanges();
            return RedirectToAction("Index","Admin");
        }

        public ActionResult Delete(int ID){
            Teacher teacher = db.Teachers.First(t => t.ID == ID);
            db.Teachers.Remove(teacher);
            db.SaveChanges();
            return RedirectToAction("Index","Admin");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
