using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.API.BusinessLogic.Interfaces;
using School.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private ICourseBL _CourseBL;

        public CourseController(ICourseBL CourseBL)
        {
            _CourseBL = CourseBL;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CourseDTO>> GetAll()
        {
            return Ok(_CourseBL.GetAll());
        }

        [HttpGet("id")]
        public ActionResult<CourseDTO> Get(int id)
        {
            return Ok(_CourseBL.GetById(id));
        }

        [HttpPost]
        public ActionResult<int> Post(CourseDTO CourseDTO)
        {
            return Ok(_CourseBL.Post(CourseDTO));
        }

        [HttpDelete("id")]
        public ActionResult<int> Delete(int id)
        {
            return Ok(_CourseBL.Delete(id));
        }

        [HttpPut]
        public ActionResult<CourseDTO> Put(int id, CourseDTO CourseDTO)
        {
            return Ok(_CourseBL.Put(CourseDTO));
        }
    }
}
