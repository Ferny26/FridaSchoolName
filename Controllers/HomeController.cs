using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Claims;  
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

using Microsoft.Extensions.Logging;
using FridaSchoolWeb.Models;

namespace FridaSchoolWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        FridaSchool db;
        Teacher teacher {get; set;}

        public HomeController(ILogger<HomeController> logger, FridaSchool injectedContext)
        {
            _logger = logger;
            db = injectedContext;
        }

        
        public ActionResult Index(string message)
        {
            ViewBag.Message = message;
            //If there's no a saved user go to logout
            if (ControllerContext.HttpContext.User.Identity.IsAuthenticated)
            {
                    return RedirectToAction("Index", "Profile");
            }else{
            return View();
            }
        }

        [HttpPost]
        /// <summary>
        /// Verify a user login and generate the corresponded cookies 
        /// </summary>
        /// <param name="roster">username</param>
        /// <param name="password">password</param>
        /// <returns></returns>
        public async Task<ActionResult> Login(string roster, string password){
            if (ModelState.IsValid)
            {
                if(!string.IsNullOrEmpty(roster) && !string.IsNullOrEmpty(password)){
                    
                    //Especial user
                    if (roster == "0000" && password == "admin")
                    {
                        //Generate the cookies and save the user data
                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, roster),
                            new Claim("FullName", "Administrator"),
                        };
                        var claimsIdentity = new ClaimsIdentity(
                            claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var authProperties = new AuthenticationProperties{
                            ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(5),
                            IsPersistent = false
                        };
                        
                        return RedirectToAction("Index","Admin");
                    }else{
                        //Verify if the user exist in the database 
                    teacher = db.Teachers.FirstOrDefault(p => p.Roaster == roster && p.Password == _encrypt(password));
                    if (teacher != null)
                    {
                        string role = "Teacher";
                        //Assign a role
                        if(teacher.GetHours() == 10){
                            role = "Cordinator";
                        } 
                        //Generate the cookies to authentication and save the tecaher information
                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, teacher.Roaster),
                            new Claim("ID", teacher.ID.ToString()),
                            new Claim("FullName", teacher.Names + " " + teacher.MiddleName),
                            new Claim(ClaimTypes.Role, role)
                        };
                        var claimsIdentity = new ClaimsIdentity(
                            claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var authProperties = new AuthenticationProperties{
                            ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(5),
                            IsPersistent = false
                        };
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
                        return RedirectToAction("Index","Profile"); 
                        
                    }else{
                        return RedirectToAction("Index","Home", new {message = "This user doesn't exist"});
                    }
                    }
                }else{
                    return RedirectToAction("Index","Home", new {message = "Fill all the fields"});

                }
            } 
            return RedirectToAction("Index","Home");

        }

        /// <summary>
        /// Encrypt the user password to verify in the database
        /// </summary>
        /// <param name="password">the user input</param>
        /// <returns></returns>

         private string _encrypt(string password){
            using (SHA256 sha256Hash = SHA256.Create()){
                byte[] data = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                var sBuilder = new StringBuilder();
                // Loop through each byte of the hashed data
                // and format each one as a hexadecimal string.
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }

                // Return the hexadecimal string.
                return sBuilder.ToString();
            }
        }

        /// <summary>
        /// Clean the session and redirect to home page 
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> Logout(){
            await HttpContext.SignOutAsync(
            CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index","Home"); 
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
