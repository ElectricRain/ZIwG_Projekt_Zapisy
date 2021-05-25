using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project_ZIwG.Domain.Auth.Interfaces;
using Project_ZIwG.Web.Models;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;

namespace Project_ZIwG.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAuthenticator _authenticator;

        public HomeController(ILogger<HomeController> logger, IAuthenticator authenticator)
        {
            _logger = logger;
            _authenticator = authenticator;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Secured()
        {
            return View();
        }

        [HttpGet("token")]
        public JwtSecurityToken Token(string username, string password)
        {
            return _authenticator.GetSecurityToken(username, password);
        }

        [HttpGet("login")]
        public IActionResult Login(string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Validate(string username, string password, string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            var claimsPrincipal = _authenticator.GetUserClaimsPrincipal(username, password);
            if(claimsPrincipal is not null)
            { 
                await HttpContext.SignInAsync(claimsPrincipal);
                return Redirect(returnUrl);
            }
            TempData["InvalidLogin"] = "username or password was incorrect!";
            return View("login");
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet("denied")]
        public IActionResult Denied()
        {
            return View();
        }
    }
}
