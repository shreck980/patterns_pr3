using Microsoft.AspNetCore.Mvc;
using patterns_pr3.Core.Entities;
using patterns_pr3.Core.FakeDataGenerators;
using patterns_pr3.Core.Proxy;
using System.Text;

namespace patterns_pr3.MVC.Controllers
{
    public class AuthorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private static List<String> _log = new List<String>();

        AuthorDAOProxy _authorDAOProxy;

        public AuthorController(AuthorDAOProxy authorDAOProxy)
        {
            
            _authorDAOProxy = authorDAOProxy;
            
        }

        [HttpPost]
        public IActionResult AddAuthor()
        {

            try
            {
                var userRole = HttpContext.Session.GetInt32("UserRole");
                _authorDAOProxy._currentUser = new User { Role = (Role)userRole };

                _log.Add($"[{DateTime.Now}] AddAuthor clicked");

                AuthorDataGenerator authorGen = new AuthorDataGenerator();
                var author = authorGen.GetFakeData();
                _authorDAOProxy.CreateAuthor(author);
                TempData["entity"] = author.ToString();
                
                TempData["log"] = string.Join("\n", _log); ;
            }
            catch (Exception e)
            {
                TempData["errors"] = e.Message;
                _log.Add(e.Message);
                TempData["log"] = string.Join("\n", _log); ;
                return RedirectToAction("UserPage", "User");
            }

            return RedirectToAction("UserPage", "User");
        }


        [HttpPost]
        public IActionResult GetAuthor(int authorId)
        {

            try
            {
                var userRole = HttpContext.Session.GetInt32("UserRole");
                _authorDAOProxy._currentUser = new User { Role = (Role)userRole };

                _log.Add($"[{DateTime.Now}] GetAuthor clicked");

                var author =  _authorDAOProxy.GetAuthor(authorId);
                TempData["entity"] = author.ToString();

                TempData["log"] = string.Join("\n", _log); ;
            }
            catch (Exception e)
            {
                TempData["errors"] = e.Message;
                _log.Add(e.Message);
                TempData["log"] = string.Join("\n", _log); ;
                return RedirectToAction("UserPage", "User");
            }

            
            return RedirectToAction("UserPage", "User");
        }

        [HttpPost]
        public IActionResult UpdateAuthor(int authorId)
        {

            try
            {
                var userRole = HttpContext.Session.GetInt32("UserRole");
                _authorDAOProxy._currentUser = new User { Role = (Role)userRole };

                _log.Add($"[{DateTime.Now}] UpdateAuthor clicked");

                AuthorDataGenerator authorGen = new AuthorDataGenerator();
                var author = authorGen.GetFakeData();
                author.Id = authorId;
                var wasAuthor = _authorDAOProxy.GetAuthor(authorId);
                _authorDAOProxy.UpdateAuthor(author);
                var authorNow = _authorDAOProxy.GetAuthor(authorId);
                TempData["entity"] = new StringBuilder().Append("Before updade:\n").Append(wasAuthor.ToString()).
                    Append("\n\nAfter updade:\n").Append(authorNow.ToString()).ToString();

                TempData["log"] = string.Join("\n", _log); ;
            }
            catch (Exception e)
            {
                TempData["errors"] = e.Message;
                _log.Add(e.Message);
                TempData["log"] = string.Join("\n", _log); ;
                return RedirectToAction("UserPage", "User");
            }

            
            return RedirectToAction("UserPage", "User");
        }
    }
}
