using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sispar.UI.WebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Sistema Integrado de Paróquias";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Factory Solution IT";

            return View();
        }
    }
}