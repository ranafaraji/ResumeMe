using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Net;
using System.Data.Entity.Infrastructure;
using Resume_Portfolio.Models;

namespace Resume_Portfolio.Controllers
{
    public class PortfolioController : Controller
    {

        // GET: api/Portfolio/ ADD
        public ActionResult Add(Information InfoAdd)
        {
            Resume_PortfolioEntities db = new Resume_PortfolioEntities();

            db.Information.Add(InfoAdd);
            db.SaveChanges();

            return RedirectToAction("Print", "Home", new { Id = InfoAdd.Id });
           
         }

        // PUT: api/Information/5 Modified
        public ActionResult Edit(int id, Information InfoEdit)
        {
            Resume_PortfolioEntities edt = new Resume_PortfolioEntities();
            if (!ModelState.IsValid) 
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (id != InfoEdit.Id){
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            edt.Entry(InfoEdit).State = EntityState.Modified;
            edt.SaveChanges();
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        // DELETE: api/Information/ Remove
        public ActionResult Delete(int id)
        {
            Resume_PortfolioEntities dlt = new Resume_PortfolioEntities();
            Information information = dlt.Information.Find(id);
            if (information == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dlt.Information.Remove(information);
            dlt.SaveChanges();

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        
        // Create: api/SignUp/ 
        public ActionResult Create(string model)
        {
            Resume_PortfolioEntities su = new Resume_PortfolioEntities();

            var signup = su.SignUps.Where(x => x.email == model).FirstOrDefault();
            if (signup != null)
            {
                ViewBag.Message = "Exist";
                return View();
            }
            else
            {
                su.SignUps.Add(signup);
                return View();
            }
        }
    }
}

