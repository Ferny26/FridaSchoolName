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
    public class SubjectController : Controller
    {
        private readonly ILogger<SubjectController> _logger;
        FridaSchool db;
        Teacher teacher {get; set;}

        public SubjectController(ILogger<SubjectController> logger, FridaSchool injectedContext)
        {
            _logger = logger;
            db = injectedContext;
        }

        public IActionResult MySubjects(string message)
        {
            int id = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(c => c.Type == "ID")?.Value);
            IQueryable<AsignaturePerTeacher> mySubjects = db.AsignaturesPerTeacher.Where(a => a.ID_Teacher == id);
            SubjectsList subjects = new SubjectsList();
            subjects.SubjectsPerTeacher = db.Subjects.Where(s => mySubjects.Any(p => p.ID_Subject == s.ID))
            .OrderByDescending(x => x.GetTotalHours())
            .ToList();
            subjects.SubjectsAvaiable = db.Subjects.Where(s => mySubjects.Any(p => p.ID_Subject != s.ID))
            .OrderByDescending(x => x.GetTotalHours())
            .ToList();
            return View(subjects);
        }
        public IActionResult AddSubject(int id){
            string roster = ControllerContext.HttpContext.User.Identity.Name;

            return RedirectToAction("Subjects");
        }

        public IActionResult Subjects(string message)
        {
            ViewBag.message = message;
            string roster = ControllerContext.HttpContext.User.Identity.Name;
            Teacher teacher = db.Teachers.First(t => t.Roaster == roster);
            IQueryable<AsignaturePerTeacher> mySubjects = db.AsignaturesPerTeacher.Where(a => a.ID_Teacher == teacher.ID);
            teacher.Subjects = db.Subjects.Where(s => mySubjects.Any(p => p.ID_Subject == s.ID))
            .OrderByDescending(x => x.GetTotalHours())
            .ToList();
            return View(teacher);
        }

        public IActionResult Create(string name, string theoryH, string practiceH){
            sbyte theoryHours = sbyte.Parse(theoryH);
            sbyte practiceHours = sbyte.Parse(practiceH);

            if((theoryHours + practiceHours) < 7 && (theoryHours + practiceHours) >0){
                Subject subject = new Subject{
                    Name = name,
                    TheoryHours = theoryHours,
                    PracticeHours = practiceHours
                };
                db.Subjects.Add(subject);
                db.SaveChanges();
            }else{
                return RedirectToAction("Subjects", new {mesage = "The hours are incorrect"});
            }
            return RedirectToAction("Subjects");
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
