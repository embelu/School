﻿using Microsoft.AspNetCore.Http;
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
    public class ClassRoomController : ControllerBase
    {
        private readonly IClassRoomBL _classRoomBL;

        public ClassRoomController(IClassRoomBL classRoomBL)
        {
            _classRoomBL = classRoomBL;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ClassRoomDTO>> GetAll()
        {
            return Ok(_classRoomBL.GetAll());
        }

        [HttpGet("id")]
        public ActionResult<ClassRoomDTO> Get(int id)
        {
            return Ok(_classRoomBL.GetById(id));
        }

        [HttpPost]
        public ActionResult<int> Post(ClassRoomDTO classRoomDTO) 
        {
            return Ok(_classRoomBL.Post(classRoomDTO));
        }

        [HttpDelete("id")]
        public ActionResult<int> Delete(int id)
        {
            return Ok(_classRoomBL.Delete(id));
        }

        [HttpPut]
        public ActionResult<ClassRoomDTO> Put(int id, ClassRoomDTO classRoomDTO)
        {
            return Ok(_classRoomBL.Put(classRoomDTO));
        }
    }
}