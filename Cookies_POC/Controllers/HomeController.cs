using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cookies_POC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        // Action to set the language preference in a cookie
        public ActionResult SetLanguage(string language)
        {
            // Create a new cookie
            HttpCookie langCookie = new HttpCookie("PreferredLanguage", language)
            {
                Expires = DateTime.Now.AddDays(7) // Cookie will expire in 7 days
            };
            // Add the cookie to the response

            Response.Cookies.Add(langCookie);
            return RedirectToAction("Index");
        }

        // Action to get the language preference from the cookie
        public ActionResult GetLanguage()
        {
            HttpCookie languageCookie = Request.Cookies["PreferredLanguage"];
            string language = languageCookie != null ? languageCookie.Value : "Not Set";
            ViewBag.Language = language;
            return View();
        }

    }
}