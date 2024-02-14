using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class detaylarController : Controller
    {
        geziEntities2 db = new geziEntities2();
        // GET: detaylar
        static int id2;

        public ActionResult detaylar(int id)
        {
            var detaylarim = db.detaylar.Find(id);

            if (detaylarim != null)
            {
                id2 = id;
                return View(detaylarim);
                //return View(new List<detaylar> {detaylarim});
            }
            else
            {
                return View("DetayBulunamadi");

            }

        }
        public ActionResult detaylar2()
        {
            int id = id2;
            var detaylarim = db.detaylar.Find(id);

            if (detaylarim != null)
            {
                ViewBag.mesaj3 = "Lütfen giriş yapınız";
                return View("detaylar", detaylarim);
                //return View(new List<detaylar> {detaylarim});
            }
            else
            {
                return View("DetayBulunamadi");

            }

        }

    }
}