using Microsoft.AspNetCore.Mvc;
using Project_ZIwG.Domain.UserGetter;
using Project_ZIwG.Infrastructure.Entities;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project_ZIwG.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserGetter _userGetter;

        public UserController(UserGetter userGetter)
        {
            _userGetter = userGetter;
        }
        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<UserEntity> Get()
        {
            return _userGetter.GetUsers();
        }

        // GET api/<UserController>/name
        [HttpGet("{name}")]
        public UserEntity Get(string name)
        {
            return _userGetter.GetByUsername(name);
        }
    }
}
