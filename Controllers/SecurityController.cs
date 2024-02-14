using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class SecurityController : Controller
    {
        geziEntities2 db = new geziEntities2();
        // GET: Security
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(admin adminim)
        {
            var useri = db.admin.FirstOrDefault(x=>x.username == adminim.username && x.sifre==adminim.sifre);
            if(useri != null)
            {
                FormsAuthentication.SetAuthCookie(useri.username, false);
                return RedirectToAction("sirketler","sirket");
            }
            else
            {
                ViewBag.Mesaj = "gecersiz";
                return View();
            }
            
        }
    }
}