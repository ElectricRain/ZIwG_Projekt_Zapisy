using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Project_ZIwG.Domain;
using Project_ZIwG.Domain.Data;
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
        public IActionResult GetSubjects()
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var response = _subjectsLogic.GetAllSubjects();
            return Ok(response);
        }


        [HttpGet("mysubjects")]
        [Authorize(Roles = "Lecturer")]
        public IActionResult GetSubjectsForUser()
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var response = _subjectsLogic.GetSubjectsForUser(userId);
            if(response.Subjects.Count == 0)
            {
                return NotFound();
            }
            return Ok(response);
        }

        [HttpGet("possiblesubjects")]
        [Authorize(Roles = "Lecturer")]
        public IActionResult GetSubjectsPossibleForUser()
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var response = _subjectsLogic.GetSubjectsPossibleForUser(userId);
            if (response.Subjects.Count == 0)
            {
                return NotFound();
            }
            return Ok(response);
        }

        [HttpGet("takensubjects")]
        [Authorize(Roles = "Lecturer")]
        public IActionResult GetSubjectsTakenByUser()
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var response = _subjectsLogic.GetSubjectsTakenByUser(userId);
            if (response.Subjects.Count == 0)
            {
                return NotFound();
            }
            return Ok(response);
        }

        [HttpPost("subjects/signin")]
        [Authorize(Roles = "Lecturer")]
        public IActionResult SignForSubject(string subjectId)
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var response = _subjectsLogic.SignForSubject(userId, subjectId);
            return Accepted(response);
        }

        [HttpPost("subjects/signout")]
        [Authorize(Roles = "Lecturer")]
        public IActionResult SignOutFromSubject(string subjectId)
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var response = _subjectsLogic.SignOutFromSubject(userId, subjectId);
            return Accepted(response);
        }

        [HttpPost("createsubject")]
        [Authorize(Roles = "Admin")]
        public IActionResult PostSubject([FromBody] SubjectDto subjectDto)
        {
            try
            {
                _subjectsLogic.CreateSubject(subjectDto);
                return Ok();
            }
            catch (System.Exception e)
            {
                return BadRequest(e);
            }            
        }
    }
}
