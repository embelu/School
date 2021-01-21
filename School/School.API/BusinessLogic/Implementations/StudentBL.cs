using School.API.BusinessLogic.Interfaces;
using School.API.Entities;
using School.API.Helpers;
using School.API.Infrastructure.Repositories;
using School.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.API.BusinessLogic.Implementations
{
    public class StudentBL : IStudentBL
    {
        private readonly IStudentRepository _StudentRepository;

        public StudentBL(IStudentRepository StudentRepository)
        {
            _StudentRepository = StudentRepository;
        }

        public int Delete(int id)
        {
            var StudentToDelete = _StudentRepository.GetById(id);
            return _StudentRepository.Delete(StudentToDelete);
        }

        public IEnumerable<StudentDTO> GetAll()
        {
            var Student = _StudentRepository.GetAll();

            return Student.Select(c => Mapper.StudentToDTO(c));
        }

        public StudentDTO GetById(int id)
        {
            var Student = _StudentRepository.GetById(id);
            return Mapper.StudentToDTO(Student);
        }

        public int Post(StudentDTO StudentDTO)
        {
            return _StudentRepository.Post(Mapper.StudentFromDTO(StudentDTO));
        }

        public StudentDTO Put(StudentDTO StudentDTO)
        {
            var StudentToUpdate = Mapper.StudentFromDTO(StudentDTO);
            return Mapper.StudentToDTO(_StudentRepository.Put(StudentToUpdate));
        }
    }
}
