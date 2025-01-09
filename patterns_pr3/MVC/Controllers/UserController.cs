using Microsoft.AspNetCore.Authentication.Cookies;

using Microsoft.AspNetCore.Mvc;
using patterns_pr3.Core.DAO;
using patterns_pr3.Core.Entities;
using patterns_pr3.Core.Proxy;
using System.Security.Claims;

namespace patterns_pr3.MVC.Controllers
{
    public class UserController : Controller
    {
        AuthenticationService _authenticstionService;
        IUserDAO _userDAO;
        public UserController(AuthenticationService authenticationService, DAOFactory factory)
        {
            _authenticstionService = authenticationService;
            _userDAO = factory.GetUserDAO();
        }
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult UserPage()
        {
            var entity = TempData["entity"];
            var log = TempData["log"];
            var errors = TempData["errors"];

           
            ViewData["Entity"] = entity;
            ViewData["Log"] = log;
            ViewData["Errors"] = errors;

            return View();
        }


        [HttpPost]
        public IActionResult Register(User model)
        {
            if (ModelState.IsValid)
            {
                
                var hashedPassword = BCrypt.Net.BCrypt.HashPassword(model.Password);

                
                var user = new User
                {
                    Login = model.Login,
                    Password = hashedPassword,
                    Role = model.Role
                };

               
                _userDAO.CreateUser(user.Login, user.Password, user.Role);

                TempData["Success"] = "Registration successful!";
                return RedirectToAction("Login", "User");
            }

           
            return View(model);
        }


        [HttpPost]
      
        public IActionResult Login(User model)
        {
            if (ModelState.IsValid)
            {
              


                var user = _authenticstionService.AuthenticateUser(model.Login, model.Password);
                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "Invalid login or password.");
                    return RedirectToAction("Login", "User"); ;
                }
                
               HttpContext.Session.SetString("UserId", user.Id.ToString());
                HttpContext.Session.SetInt32("UserRole", (int)user.Role);
                
                
                return RedirectToAction("UserPage","User");

            }


           
            return View(model);
        }
    }
}
