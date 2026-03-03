using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentAPI.Models;
using StudentAPI.Service;
using StudentAPI.Services;

namespace StudentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassesController : ControllerBase
    {
        IClassesService services;
        public ClassesController(IClassesService _services)
        {
            services = _services;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(services.GetAllClasses());
        }

        [HttpGet("{classname}")]
        public IActionResult Get(string classname)
        {
            return Ok(services.GetById(classname));
        }

        [HttpPost]
        public IActionResult Post(ClassesModel classes)
        {
            try
            {
                services.Create(classes);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPut]

        public IActionResult Put(string classname,ClassesModel classes)
        {
            try
            {
                services.Update(classname, classes);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult Delete(string classname)
        {
            try
            {
                services.Delete(classname);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        
    }
}
