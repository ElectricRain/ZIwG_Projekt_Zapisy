using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Project_ZIwG.Domain;
using Project_ZIwG.Domain.Data;
using Project_ZIwG.Domain.UserGetter;
using Project_ZIwG.Infrastructure.Entities;
using System.Collections.Generic;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project_ZIwG.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyCorsPolicy")]
    public class UserController : ControllerBase
    {
        private readonly SubjectsLogic _subjectsLogic;

        public UserController(SubjectsLogic subjectsLogic)
        {
            _subjectsLogic = subjectsLogic;
        }

        // GET api/<UserController>/name
        [HttpGet("subjects")]
        [Authorize(Roles = "Lecturer")]
        public SubjectResponse GetSubjects()
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return _subjectsLogic.GetAllSubjects();
        }


        [HttpGet("mysubjects")]
        [Authorize(Roles = "Lecturer")]
        public SubjectResponse GetSubjectsForUser()
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return _subjectsLogic.GetSubjectsForUser(userId);
        }

        [HttpGet("possiblesubjects")]
        [Authorize(Roles = "Lecturer")]
        public SubjectResponse GetSubjectsPossibleForUser()
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return _subjectsLogic.GetSubjectsPossibleForUser(userId);
        }

        [HttpGet("takensubjects")]
        [Authorize(Roles = "Lecturer")]
        public SubjectResponse GetSubjectsTakenByUser()
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return _subjectsLogic.GetSubjectsTakenByUser(userId);
        }

        [HttpPost("subjects/signin")]
        [Authorize(Roles = "Lecturer")]
        public IActionResult SignForSubject(string subjectId)
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            _subjectsLogic.SignForSubject(userId, subjectId);
            return new OkResult();
        }

        [HttpPost("subjects/signout")]
        [Authorize(Roles = "Lecturer")]
        public IActionResult SignOutFromSubject(string subjectId)
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            _subjectsLogic.SignOutFromSubject(userId, subjectId);
            return new OkResult();
        }
    }
}
