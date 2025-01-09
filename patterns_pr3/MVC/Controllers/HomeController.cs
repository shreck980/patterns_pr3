using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using patterns_pr3.Core.Builder;
using patterns_pr3.Core.DAO;
using patterns_pr3.Core.Entities;
using patterns_pr3.Core.FakeDataGenerators;
using patterns_pr3.Core.Memento;

namespace patterns_pr3.MVC.Controllers
{
    public class HomeController : Controller
    {
        
        DAOFactory daoFactory { get; set; }
        PublicationCaretaker caretaker { get; set; }
        Publication originator { get; set; }
        private static List<String> _log = new List<String>();
      
        public HomeController(DAOFactory daoFactory, PublicationCaretaker caretaker)
        {
            this.daoFactory = daoFactory;
            this.caretaker = caretaker;
            
        }

        // GET: HomeController
        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PublicationMemento p)
        {
           
            if (p is null)
            {
               
                TempData["Message"] = "Publication was null :(";
                return View("PublicationEditor",p);
            }
            originator = new PublicationBuilder().SetId(p.Id).SetTitle(p.Title)
                .SetPageCount(p.PageCount).SetCirculation(p.Circulation).SetPrice(p.Price).SetQuantity(p.Quantity)
                .SetAuthors(p.Authors).Build();
            _log.Add( caretaker.Save(originator.SaveState()));
            //HttpContext.Session.SetString("Messages", "");
         
            TempData["Messages"] = _log;
           

            return View("PublicationEditor",p); ;
        }

        public ActionResult Back()
        {
            try
            {
                PublicationMemento p = caretaker.Previous();
                if (p is null)
                {
                    _log.Add("nO SUCCESS P IS NULL");
                    return View("PublicationEditor"); ;
                }

                _log.Add($"Попередній стан: {p}");

                TempData["Messages"] = _log;
                return View("PublicationEditor", p);
            }
            catch(Exception e)
            {
                _log.Add(e.Message);
                TempData["Messages"] = _log;
            }
            return View("PublicationEditor", new PublicationMemento());
        }

        public ActionResult Delete()
        {

            _log.Add( caretaker.DeletePublication());


            PublicationMemento p =  new PublicationMemento();

            TempData["Messages"] = _log;
            return View("PublicationEditor", p); ;
        }

        public ActionResult Next()
        {
            try
            {
                PublicationMemento p = caretaker.Next();
                if (p is null)
                {
                    _log.Add("nO SUCCESS P IS NULL");
                    return View("PublicationEditor"); ;
                }

                _log.Add($"Наступний стан: {p} ");


                TempData["Messages"] = _log;
                return View("PublicationEditor", p);

            }
            catch(Exception ex)
            {
                _log.Add(ex.Message);
                TempData["Messages"] = _log;
            }
            return  View("PublicationEditor", new PublicationMemento());
        }

        public ActionResult PublicationEditor()
        {
           Random random = new Random();
           Publication? p=  daoFactory.GetPublicationDAO()?.GetPublication(1);
           originator = new PublicationBuilder().SetId(p.Id).SetTitle(p.Title)
                .SetPageCount(p.PageCount).SetCirculation(p.Circulation).SetPrice(p.Price).SetQuantity(p.Quantity)
                .SetAuthors(p.Authors).Build();
           PublicationMemento pm = originator.SaveState();
           caretaker.Save(originator.SaveState());
            if (p is not null)
            {
                return View("PublicationEditor", pm);
            }
            else
            {
                return View("Error",pm);
            }
        }



      

    }
}
