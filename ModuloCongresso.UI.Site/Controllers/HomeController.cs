using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModuloCongresso.UI.Site.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Info()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Infra()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Local()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult News()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Quest()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}