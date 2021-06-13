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


        [HttpGet("token")]
        public IActionResult LoginToken(string username, string password)
        {
            var authToken = _authenticator.GetSecurityToken(username, password);
            if(authToken == null)
            {
                return BadRequest("Wrong username or password");
            }
            return Ok(new
            {
                token = authToken
            });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
