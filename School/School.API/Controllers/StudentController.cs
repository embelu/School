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
    public class StudentController : ControllerBase
    {
        private readonly IStudentBL _StudentBL;

        public StudentController(IStudentBL StudentBL)
        {
            _StudentBL = StudentBL;
        }

        [HttpGet]
        public ActionResult<IEnumerable<StudentDTO>> GetAll()
        {
            return Ok(_StudentBL.GetAll());
        }

        [HttpGet("id")]
        public ActionResult<StudentDTO> Get(int id)
        {
            return Ok(_StudentBL.GetById(id));
        }

        [HttpPost]
        public ActionResult<int> Post(StudentDTO StudentDTO)
        {
            return Ok(_StudentBL.Post(StudentDTO));
        }

        [HttpDelete("id")]
        public ActionResult<int> Delete(int id)
        {
            return Ok(_StudentBL.Delete(id));
        }

        [HttpPut]
        public ActionResult<StudentDTO> Put(int id, StudentDTO StudentDTO)
        {
            return Ok(_StudentBL.Put(StudentDTO));
        }
    }
}
