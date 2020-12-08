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
    public class GroupController : Controller
    {
        private readonly ILogger<GroupController > _logger;
        FridaSchool db;
        Teacher teacher {get; set;}

        public GroupController (ILogger<GroupController > logger, FridaSchool injectedContext)
        {
            _logger = logger;
            db = injectedContext;
        }

        /// <summary>
        /// Allow see the groups that the teacher has 
        /// </summary>
        /// <returns>the view with two tables</returns>
        public IActionResult MyGroups()
        {
            if(!HttpContext.User.Identity.IsAuthenticated){
                return RedirectToAction("Logout","Home");
            }else{
            //Verify the user by cookies
            int id = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(c => c.Type == "ID")?.Value);
            IQueryable<Sort> myGroups = db.Sort.Where(a => a.ID_Teacher == id);
            List<(Group,Subject)> asignature = new List<(Group, Subject)>();
            //Take the subjects and their corresponded groups
            foreach(var item in myGroups){
                Group group = db.Groups.First(g => g.ID == item.ID_Group);
                Subject subject = db.Subjects.First(s => s.ID == item.ID_Subject);
                asignature.Add((group, subject));
            }
            return View(asignature);
            }
        }

        /// <summary>
        /// Allow see all subjects only for the cordinators 
        /// </summary>
        /// <returns>The view with the groups</returns>
        public IActionResult Groups()
        {
            if(!HttpContext.User.Identity.IsAuthenticated){
                return RedirectToAction("Logout","Home");
            }else{
            IQueryable<Group> groups = db.Groups;
            return View(groups);
            }
        }

        [HttpPost]

        /// <summary>
        /// Allow edit a group
        /// </summary>
        /// <param name="name"> gropu name</param>
        /// <param name="period">group period</param>
        /// <param name="id">goup id to edit</param>
        /// <returns></returns>
        public IActionResult Edit( string name, string period, int id)
        {
            Group group = db.Groups.First(s => s.ID == id);
            group.Name = name;
            group.Period = Boolean.Parse(period);
            group.StablishDates();
            db.Groups.Update(group);
            db.SaveChanges();
            return RedirectToAction("Groups","Group");
        }

        /// <summary>
        /// Allow delete a specific group
        /// </summary>
        /// <param name="id">group id to delete</param>
        /// <returns></returns>
        public IActionResult Delete(int id){
            Group group = db.Groups.First(s => s.ID == id); 
            db.Groups.Remove(group);
            db.SaveChanges();
            return RedirectToAction("Groups","Group");
        }

        [HttpPost]

        /// <summary>
        /// Create a new group
        /// </summary>
        /// <param name="name">group name</param>
        /// <param name="period">period name</param>
        /// <returns>the principal view with all groups</returns>
        public IActionResult Create(string name, string period){
            Group group = new Group{
                Name = name,
                Period = Boolean.Parse(period),
            };
            group.StablishDates();
            db.Groups.Add(group);
            db.SaveChanges();
            return RedirectToAction("Groups","Group");
        }

    /// <summary>
    /// Allow see the specific group too add or remove sibjects 
    /// </summary>
    /// <param name="id">group id</param>
    /// <returns>the view with all groups</returns>
            public IActionResult Group(int id){
            Group group = db.Groups.First(g => g.ID == id);
            TempData ["ID_Group"] = group.ID;
            SubjectsGroupList subjectsPerGroup = new SubjectsGroupList();
            subjectsPerGroup.Group = group;
            //Take the subjects that the group has
            List<GroupSubjects> groupSubjects = db.GroupSubjects.Where(a => a.ID_Group == id).ToList();
            List<Subject> subjects = db.Subjects.ToList();
            subjectsPerGroup.SubjectsPerGroup = subjects.Where(a => groupSubjects.Any(b => b.ID_Subject == a.ID))
            .OrderBy(a => a.GetTotalHours())
            .ToList();
            //Take the subjects that the group doesn't has 
            subjectsPerGroup.SubjectsAvaiable = subjects.Where(a => groupSubjects.Any(b => b.ID_Subject != a.ID))
            .OrderBy(a => a.GetTotalHours())
            .ToList();
            return View(subjectsPerGroup);
        }


        /// <summary>
        /// Allow add suject to group
        /// </summary>
        /// <param name="id">subject id</param>
        /// <returns>the view with all groups</returns>
        public IActionResult AddSubject(int id){
            int idGroup = (int)TempData["ID_Group"];
            GroupSubjects asignatureRegister = new GroupSubjects{
                ID_Subject = id,
                ID_Group = idGroup
            };
            db.GroupSubjects.Add(asignatureRegister);
            db.SaveChanges();
            return RedirectToAction("Group", new{id = idGroup});
        }

        /// <summary>
        /// Remove one subject of the group subjects list
        /// </summary>
        /// <param name="id">subject id</param>
        /// <returns>the view with all groups</returns>
        public IActionResult RemoveSubject(int? id){
            int idGroup = (int)TempData["ID_Group"];
            if (id != null)
            {
            GroupSubjects asignatureRegister = db.GroupSubjects.First(a => a.ID_Subject == id && a.ID_Group == idGroup);
            db.GroupSubjects.Remove(asignatureRegister);
            db.SaveChanges();
            }
            return RedirectToAction("Group", new{id = idGroup});
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
