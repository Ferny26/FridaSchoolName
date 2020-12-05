using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FridaSchoolWeb.Models;
namespace FridaSchoolWeb.Controllers
{
    public class ProfileController : Controller
    {
        private readonly ILogger<ProfileController> _logger;
        FridaSchool db;

        public ProfileController(ILogger<ProfileController> logger, FridaSchool injectedContext)
        {
            _logger = logger;
            db = injectedContext;
            
        }
        
        public IActionResult Index()
        {
            string roster = ControllerContext.HttpContext.User.Identity.Name;
            Teacher teacher = db.Teachers.First(t => t.Roaster == roster);
            return View(teacher);
        }

        public IActionResult Edit(){
            string roster = ControllerContext.HttpContext.User.Identity.Name;
            Teacher teacher = db.Teachers.First(t => t.Roaster == roster);
            return View(teacher);
        }

        [HttpPost]
        public IActionResult Edit(string names, string middleName, string lastName, string birthDate, string genre){
            string roster = ControllerContext.HttpContext.User.Identity.Name;
            Teacher teacher = db.Teachers.First(t => t.Roaster == roster);
            teacher.Names = names.ToUpper();
            teacher.MiddleName = middleName.ToUpper();
            teacher.LastName = lastName.ToUpper();
            teacher.BirthDate = DateTime.Parse(birthDate);
            teacher.Gender = genre[0];
            teacher.KeysGenerator();
            db.Teachers.Update(teacher);
            db.SaveChanges();
            return RedirectToAction("Index", "Profile");
        }
    }

}