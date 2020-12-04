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
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        FridaSchool db;
        Teacher teacher;

        public HomeController(ILogger<HomeController> logger, FridaSchool injectedContext)
        {
            _logger = logger;
            db = injectedContext;
        }

        public IActionResult Index(string message)
        {
            ViewBag.Message = message;
            return View();
        }

        [HttpPost]
        public ActionResult Login(string roster, string password){
            if (ModelState.IsValid)
            {
                if(!string.IsNullOrEmpty(roster) && !string.IsNullOrEmpty(password)){
                    teacher = db.Teachers.FirstOrDefault(p => p.Roaster == roster && p.Password == password);
                    if (teacher != null)
                    {
                        //Session["idUser"] = teacher.ID;
                        //Session["FullName"] = teacher.Names +" "+ teacher.LastName;
                    }else{
                        return RedirectToAction("Index","Home", new {message = "This user doesn't exist"});
                    }
                }else{
                    return RedirectToAction("Index","Home", new {message = "Fill all the fields"});

                }
            }
            return RedirectToAction("Index","Profile", teacher);

        }


        public IActionResult Privacy()
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
