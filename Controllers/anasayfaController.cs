using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class anasayfaController : Controller
    {
        geziEntities2 db = new geziEntities2();

        // GET: anasayfa
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult turlar()
        {
            var model = db.detaylar.ToList();
            return View(model);
        }

        public ActionResult sirketlera()
        {
            var model = db.departman.ToList();
            return View(model);


        }
        public ActionResult bookinkgsirketsecim(int id)
        {
            var model2 = new booking { sirketid = id };
            ViewData["id"] = model2.sirketid;
            //ViewBag.medel2 = model2.sirketid;
            var model = db.departman.ToList();
            return View(model);


        }
        [HttpGet]
        public ActionResult Uyeol()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Uyeol(user user)
        {
            var useri = db.user.FirstOrDefault(x => x.username == user.username);
            if (useri != null)
            {
                ViewBag.Mesaj = "Kullanıcı adı kullanımda farklı bir kullanıcı adı giriniz";
                return View();
            }
            else if (user != null)
            {

                ViewBag.Mesaj1 = "Kayıt olundu";
                db.user.Add(user);
            }
            else
            {
                ViewBag.Mesaj = "Başarısız";
                return View();
            }
            db.SaveChanges();
            return View("Login");
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Login(user user)
        {
            var useri = db.user.FirstOrDefault(x => x.username == user.username && x.password == user.password);
            if (useri != null)
            {
                FormsAuthentication.SetAuthCookie(useri.username, false);
                return RedirectToAction("Index", "anasayfa");
            }
            else
            {
                ViewBag.Mesaj = "gecersiz";
                return View();
            }

        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "anasayfa"); 
        }



    }
}
