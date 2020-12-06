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
    public class SortController : Controller
    {
        private readonly ILogger<SortController> _logger;
        FridaSchool db;
        Teacher teacher {get; set;}

        public SortController(ILogger<SortController> logger, FridaSchool injectedContext)
        {
            _logger = logger;
            db = injectedContext;
        }

        public IActionResult Index(string message)
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
