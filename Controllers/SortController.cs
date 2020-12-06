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
            #region Variables
            bool fail = false;  
            IQueryable<Teacher> teachers = db.Teachers;
            IQueryable<Group> groups = db.Groups;
            List<Subject> subjects = new List<Subject>();
            #endregion
            if (groups != null )
            {
                foreach (var item in groups)
                {
                    IQueryable<Sort> sort = db.Sort.Where(s => s.ID_Group == item.ID);
                    if (sort != null)
                    {
                        foreach (var item2 in sort)
                        {
                            subjects.Add(db.Subjects.First(x => x.ID == item2.ID_Subject));
                        }
                        foreach (var item3 in subjects)
                        {
                            Teacher teacher = candidateRestrictedList(item3);
                        }
                    }else
                    {
                        fail = true;
                        break;
                    }
                }
            }

            return View();
        }

        public Teacher candidateRestrictedList(Subject subject){
                    Teacher teacher = null;
                    //Get the teachers list that can teach this sibject
                    IQueryable<AsignaturePerTeacher> teachersLRC = db.AsignaturesPerTeacher.Where(a => a.ID_Subject == subject.ID);
                    if (teachersLRC != null)
                    {
                        List<Teacher> teachers = new List<Teacher>();
                        foreach (var item in teachersLRC)
                        {
                            teachers.Add(db.Teachers.First(t => t.ID == item.ID_Teacher));
                        }
                        //Take the employees that don't have their complete hours or groups  
                        teachers = teachers.Where(x => (x.assignedHours + subject.GetTotalHours()) <= x.GetHours()  && x.assignedGroups < 5 ).ToList();
                        //Order by the employees that have lees subjects to teach 
                        //and then by the employees that don't have the hours half complete
                        
                    }
                    return teacher;
                    }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
