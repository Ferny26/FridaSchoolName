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
            if(!HttpContext.User.Identity.IsAuthenticated){
                return RedirectToAction("Logout","Home");
            }else{
            string roster = ControllerContext.HttpContext.User.Identity.Name;
            Teacher teacher = db.Teachers.First(t => t.Roaster == roster);
            return View(teacher);
            }
        }

        /// <summary>
        /// Return the view to show the user information to edit
        /// </summary>
        /// <returns></returns>
        public IActionResult Edit(){
            string roster = ControllerContext.HttpContext.User.Identity.Name;
            Teacher teacher = db.Teachers.First(t => t.Roaster == roster);
            return View(teacher);
        }

        [HttpPost]
        /// <summary>
        /// Allow the user edit some field and save the changes
        /// </summary>
        /// <param name="names">teacher name</param>
        /// <param name="middleName">tecaher middlename</param>
        /// <param name="lastName">teacher lastname</param>
        /// <param name="birthDate">teacher birthdate</param>
        /// <param name="genre">teacher genre</param>
        /// <returns></returns>
        public IActionResult Edit(string names, string middleName, string lastName, string birthDate, string genre){
            string roster = ControllerContext.HttpContext.User.Identity.Name;
            Teacher teacher = db.Teachers.First(t => t.Roaster == roster);
            teacher.Names = names.ToUpper();
            teacher.MiddleName = middleName.ToUpper();
            teacher.LastName = lastName.ToUpper();
            teacher.BirthDate = DateTime.Parse(birthDate);
            teacher.Gender = genre[0];
            //After put the information generate again the keys
            teacher.KeysGenerator();
            db.Teachers.Update(teacher);
            db.SaveChanges();
            return RedirectToAction("Index", "Profile");
        }
    }

}