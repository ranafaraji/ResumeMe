using Resume_Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Resume_Portfolio.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            SignUp signFirst = new SignUp();
            ViewBag.Title = "Home Page";

            return View(signFirst);
        }

        public ActionResult Print(int id)
        {
            Resume_PortfolioEntities db = new Resume_PortfolioEntities();
            var info = db.Information.FirstOrDefault(item => item.Id == id);
            return View(info);
        }

        [HttpPost]
        public ActionResult Index(SignUp model)
        {
            Resume_PortfolioEntities su = new Resume_PortfolioEntities();

            var signup = su.SignUps.Where(x => x.email == model.email).FirstOrDefault();
            if (signup != null)
            {
                ViewBag.Message = "Exist";
                return View();
            }
            else
            {
                //su.SignUps.Add(signup);
                return View("Portfolio", signup );



            }
        }
    }
}