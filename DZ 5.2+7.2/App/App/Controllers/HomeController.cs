using App.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly airportdbContext _context;
        private readonly ISession session;

        public HomeController(ILogger<HomeController> logger, airportdbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _context = context;
            this.session = httpContextAccessor.HttpContext.Session;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string? Username, string? Password)
        {
            if (Username == null || Password == null)
            {
                return NotFound();
            }

            var user = await _context.Employees.FirstOrDefaultAsync(x => x.Username == Username && x.Password == Password);
            if (user == null)
            {
                return Error();
            }
            var x = HttpContext.Session;
            x.SetString("name", user.Firstname + " " + user.Lastname);
            ViewData["Name"] = user.Firstname + " " + user.Lastname;
            return View("Views/Home/Index.cshtml");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
