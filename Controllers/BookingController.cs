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
    public class BookingController : Controller
    {
        geziEntities2 db = new geziEntities2();


        // GET: Booking
        public ActionResult Index()
        {
           
            var user2 = aktifuser();
            if (user2 == null) {
            
                return View("Index2");
            }
            ViewBag.mesaj = user2.age;
            var model = db.booking.Where(x => x.userid == user2.id).ToList();
            return View(model);
        }
        public ActionResult addbooking(int id, int id2)
        {

            //var aktifuser1 = new activeuser();

            //aktifuser1.userbul(HttpContext httpContext);
            string cookieName = FormsAuthentication.FormsCookieName; //Find cookie name
            HttpCookie authCookie = HttpContext.Request.Cookies[cookieName]; //Get the cookie by it's name
            if (authCookie == null)
            {

                return RedirectToAction("detaylar2", "detaylar", id);
            }
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value); //Decrypt it
            string UserName = ticket.Name;
            var user1 = db.user.FirstOrDefault(x => x.username == UserName);

            var bookingim = new booking { userid = user1.id, sirketid = id2, turid = id };
            db.booking.Add(bookingim);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public user aktifuser()
        {

            
            string cookieName = FormsAuthentication.FormsCookieName; //Find cookie name
            HttpCookie authCookie = HttpContext.Request.Cookies[cookieName]; //Get the cookie by it's name
            if (authCookie == null)
            {

                return null;
            }
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value); //Decrypt it
            string UserName = ticket.Name;
            var user1 = db.user.FirstOrDefault(x => x.username == UserName);
            return user1;
        }
        public ActionResult sil(int id)
        {
            var sillenecek = db.booking.Find(id);
            if (sillenecek == null)
                return HttpNotFound();
            db.booking.Remove(sillenecek);
            db.SaveChanges();

            return RedirectToAction("Index");


        }
    }
}