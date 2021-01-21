using School.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.API.Infrastructure.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly SchoolContext _context;

        public CourseRepository(SchoolContext schoolContext)
        {
            _context = schoolContext;
        }

        public int Delete(Course Course)
        {
            _context.Remove(Course);
            _context.SaveChanges();
            return Course.Id;
        }

        public IEnumerable<Course> GetAll()
        {
            return _context.Courses;
        }

        public Course GetById(int id)
        {
            return _context.Courses.Find(id);
        }

        public int Post(Course Course)
        {
            _context.Add(Course);
            _context.SaveChanges();
            return Course.Id;
        }

        public Course Put(Course Course)
        {
            _context.Update(Course);
            _context.SaveChanges();
            return Course;
        }
    }
}
