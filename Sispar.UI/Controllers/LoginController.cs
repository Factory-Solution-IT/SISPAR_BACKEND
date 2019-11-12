using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Sispar.Core.Contracts.Services;
using Sispar.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Sispar.UI.Controllers
{
    public class LoginController: Controller
    {
        private readonly IUserService _context;

        public LoginController(IUserService context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(LoginVM model)
        {
            try
            {
                var user = _context.Login(model.Username, model.Password);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                return Content($"Login Failed: {ex.Message}");
            }
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
    }
}
