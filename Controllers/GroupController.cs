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

        public IActionResult MyGroups(string message)
        {
            int id = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(c => c.Type == "ID")?.Value);
            IQueryable<Sort> myGroups = db.Sort.Where(a => a.ID_Teacher == id);
            List<(Group,Subject)> asignature = new List<(Group, Subject)>();
            foreach(var item in myGroups){
                Group group = db.Groups.First(g => g.ID == item.ID_Group);
                Subject subject = db.Subjects.First(s => s.ID == item.ID);
                asignature.Add((group, subject));
            }
            return View(asignature);
        }
 

        public IActionResult Groups(string message)
        {
            ViewBag.message = message;
            IQueryable<Group> groups = db.Groups;
            return View(groups);
        }

        [HttpPost]
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

        public IActionResult Delete(int id){
            Group group = db.Groups.First(s => s.ID == id); 
            db.Groups.Remove(group);
            db.SaveChanges();
            return RedirectToAction("Groups","Group");
        }

        [HttpPost]
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
