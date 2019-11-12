using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sispar.UI.Controllers
{
    public class TitherController: Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
