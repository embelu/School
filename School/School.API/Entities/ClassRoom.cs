using System;
using System.Collections.Generic;

#nullable disable

namespace School.API.Entities
{
    public partial class ClassRoom
    {
        public ClassRoom()
        {
            Courses = new HashSet<Course>();
        }

        public int Id { get; set; }
        public string Label { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
