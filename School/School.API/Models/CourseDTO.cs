using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.API.Models
{
    public class CourseDTO
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public int ClassRoomId { get; set; }
    }
}
