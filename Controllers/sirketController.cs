using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class sirketController : Controller
    {
        geziEntities2 db = new geziEntities2();
        // GET: sirket
        [Authorize]
        public ActionResult sirketler()
        {
            var model = db.departman.ToList();
            return View(model);
        }
        [HttpGet]
        public ActionResult ekle()
        {
            //var model = db.departman.ToList();               

            return View();
        }
        [HttpPost]
        public ActionResult ekle(string name, int? phone, string address)
        {
            var Departman = new departman()
            {
                ad = name,
                telefon = phone,
                konum = address
            };
            
            db.departman.Add(Departman);

            db.SaveChanges();
            
            return RedirectToAction("sirketler");
        }

        public ActionResult sil(int id)
        {
            var sillenecek = db.departman.Find(id);
            if (sillenecek == null)
                return HttpNotFound();
            db.departman.Remove(sillenecek);
            db.SaveChanges();

            return RedirectToAction("sirketler");


        }
        
    }
}