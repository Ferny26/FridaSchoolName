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
        Teacher teacher;

        public ProfileController(ILogger<ProfileController> logger, FridaSchool injectedContext)
        {
            _logger = logger;
            db = injectedContext;
            
        }

        public IActionResult Index( Teacher user)
        {
            teacher = user;
            return View(teacher);
        }


    }
}