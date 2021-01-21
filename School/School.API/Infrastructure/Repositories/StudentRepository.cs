using School.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.API.Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly SchoolContext _context;

        public StudentRepository(SchoolContext schoolContext)
        {
            _context = schoolContext;
        }

        public int Delete(Student Student)
        {
            _context.Remove(Student);
            _context.SaveChanges();
            return Student.Id;
        }

        public IEnumerable<Student> GetAll()
        {
            return _context.Students;
        }

        public Student GetById(int id)
        {
            return _context.Students.Find(id);
        }

        public int Post(Student Student)
        {
            _context.Add(Student);
            _context.SaveChanges();
            return Student.Id;
        }

        public Student Put(Student Student)
        {
            _context.Update(Student);
            _context.SaveChanges();
            return Student;
        }
    }
}
