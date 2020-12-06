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

        /// <summary>
        /// Show the view with the sort 
        /// </summary>
        /// <param name="message">if some was wrong send a message with the error</param>
        /// <returns>The view with the sort data</returns>
        public ActionResult Index(string message){
            ViewBag.message = message;
            if (!String.IsNullOrEmpty(message))
            {
                //If there's a message, truncate the table
                var all = from c in db.Sort select c;
                db.Sort.RemoveRange(all);
                db.SaveChanges();
                return View();
            }else
            {
                IQueryable<Sort> sort = db.Sort;
                List<SortDetails> sortDetails = new List<SortDetails>();
                //Take a list with the teachers, subjects and groups
                foreach (var item in sort)
                {
                    Teacher teacher = db.Teachers.First(x => x.ID == item.ID_Teacher);
                    Subject subject = db.Subjects.First(x => x.ID == item.ID_Subject);
                    Group group = db.Groups.First(x => x.ID == item.ID_Group);
                    sortDetails.Add(new SortDetails{
                        Teacher = teacher,
                        Subject = subject,
                        Group = group
                        });
                }
                return View(sortDetails);
            }
            
        }

        /// <summary>
        /// Generate the sort for the groups, teachers and subjects 
        /// </summary>
        /// <returns></returns>
        public ActionResult GenerateSort()
        {
            //Clean the sort table 
            #region Clean
                var all = from c in db.Sort select c;
                db.Sort.RemoveRange(all);
                db.SaveChanges();
            #endregion
            
            #region Variables
            IQueryable<Teacher> teachers = db.Teachers;
            IQueryable<Group> groups = db.Groups;
            IQueryable<Subject> subjects = null;
            #endregion
            #region upload subjects list
            //For each teacher upload the subjects number that it has 
                foreach (var item in teachers)
                {
                    IQueryable<AsignaturePerTeacher> asignatures = db.AsignaturesPerTeacher.Where(a => a.ID_Teacher == item.ID);
                    item.subjects = asignatures.Count();
                }
            #endregion
            //Check if there's some groups
            if (groups != null )
            {
                foreach (var item in groups)
                {
                    //Verify if the group has subjects
                    IQueryable<GroupSubjects> groupsSubject = db.GroupSubjects.Where(s => s.ID_Group == item.ID);
                    if (groupsSubject != null)
                    {
                        //Take the group subjects list
                        subjects = db.Subjects.Where(x => groupsSubject.Any(y => y.ID_Subject == x.ID));
                        foreach (var item2 in subjects)
                        {
                            //Take the teachers that can teach the subject order and take the best option
                            IQueryable<AsignaturePerTeacher> teachersAvaiables = db.AsignaturesPerTeacher.Where(a => a.ID_Subject == item2.ID);
                            List<Teacher> teachersLRC = teachers.Where(x => teachersAvaiables.Any(y => y.ID_Teacher == x.ID)).ToList();
                            teachersLRC = teachersLRC.Where(x => (x.assignedHours + item2.GetTotalHours()) <= x.GetHours()  && x.assignedGroups < 5 ).ToList();
                            teachersLRC = teachersLRC.OrderBy(x => x.subjects)
                            .ThenByDescending(x => (x.GetHours()/2 - x.assignedHours))
                            .ToList();
                            if (teachersLRC.Count != 0)
                            {
                                //If there's some avaible teacher create the row to sort with all information
                                Teacher teacher = teachersLRC[0];
                                teacher.assignedGroups = (sbyte)(teacher.assignedGroups + 1);
                                teacher.assignedHours = (sbyte) (teacher.assignedHours + item2.GetTotalHours());
                                Sort sort = new Sort{
                                    ID_Teacher = teacher.ID,
                                    ID_Group = item.ID,
                                    ID_Subject =item2.ID
                                };
                                db.Sort.Add(sort);
                                db.SaveChanges();
                            }else
                            {
                                return RedirectToAction("Index", new {message = "There's not enough teachers per subjects"});
                            }
                        }  
                    }else
                    {
                        return RedirectToAction("Index", new {message = "One or more groups doesn't have subjects"});
                    }
                }
                    //Finally verify if the all teachers have the minimun hours  
                    var teachersCounter = teachers.Where(x => x.assignedHours >= x.GetHours()/2).ToList();
                    //Verify if the teacher have the minimun hours 
                    if (teachersCounter.Count() == teachers.Count())
                    {
                        return RedirectToAction("Index");
                    }else
                    {
                        return RedirectToAction("Index", new {message = "The teachers don't have the minimum hours with the actual information"});
                        
                    }
            }else{
                return RedirectToAction("Index", new {message = "There's no groups"});
            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
