using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sispar.UI.WebApp.Controllers
{
    public class ReportController : Controller
    {
//        private readonly TitherRepository _ctx = new TitherRepository();
        // GET: Report
        public ActionResult Index()
        {
            return View();
        }
    }
}