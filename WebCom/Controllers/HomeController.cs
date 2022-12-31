using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebCom.Data;
using WebCom.Models;
using WebCom.Models.Views.Home;
using WebCom.Services.Interfaces;

namespace WebCom.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAuthenticationService _authenticationService;

        public HomeController(ILogger<HomeController> logger, WebComContext context,
            IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
            _logger = logger;
        }

        public IActionResult Login(LoginVM loginVM)
        {
            bool isAuthenticated = _authenticationService.AuthenticateUser(loginVM.Email, loginVM.Password);

            if (isAuthenticated)
            {
                HttpContext.Session.SetString("IsAuthenticated", loginVM.Email);
            }
            return RedirectToAction("Index");
        }

        public IActionResult CreateUser(LoginVM loginVM)
        {
            if (loginVM == null || string.IsNullOrWhiteSpace(loginVM.Email))
            {
                return View();
            }
            else
            {
                _authenticationService.CreateUser(loginVM.Email, loginVM.Password);
                return RedirectToAction("Index");
            }
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}