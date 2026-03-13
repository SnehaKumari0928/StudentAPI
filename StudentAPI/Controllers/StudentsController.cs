using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using StudentAPI.Helpers;
using StudentAPI.Models;
using StudentAPI.Service;
using System.Xml.Serialization;

namespace StudentAPI.Controllers
{
    [Route("api/[controller]")] // attribute routing
    [ApiController] // model validation
    public class StudentsController : ControllerBase
    {
        IStudentService service;
        IConfiguration config;
        public StudentsController(IStudentService _service,IConfiguration _config)
        {
            service = _service;
            config = _config;
        }
        [Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(service.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(service.GetById(id));
        }

        [HttpPost("create")]
        public IActionResult Post(StudentModel student)
        {
            try
            {
                service.Create(student);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpPost("register")]
        public IActionResult Register(StudentModel student)
        {
            try
            {
                if (service.Register(student))
                {
                    return Ok();
                }

                return BadRequest("User already exists.");
                
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpPost("login")]
        public IActionResult Login(StudentModel student)
        {
            var user = service.Login(student);
            if(user == null)
            {
                return BadRequest("Invalid credentials");
            }

            var accessToken = TokenHelper.GenerateAccessToken(user, config);
            var refreshToken = TokenHelper.GenerateRefreshToken();

            service.SaveRefreshToken(user.id, refreshToken);

            return Ok(new
            {
                accessToken,
                refreshToken
            });
        }

        [Authorize]
        [HttpPut]
        public IActionResult Put(StudentModel student, int id)
        {
            try
            {
                service.Update(student,  id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [Authorize]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                service.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
    }
}
