using System;
using System.Collections.Generic;

#nullable disable

namespace School.API.Entities
{
    public partial class Course
    {
        public Course()
        {
            StudentCourses = new HashSet<StudentCourse>();
        }

        public int Id { get; set; }
        public string Label { get; set; }
        public int ClassRoomId { get; set; }

        public virtual ClassRoom ClassRoom { get; set; }
        public virtual ICollection<StudentCourse> StudentCourses { get; set; }
    }
}
