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
    public class CourseBL : ICourseBL
    {
        private readonly ICourseRepository _CourseRepository;

        public CourseBL(ICourseRepository CourseRepository)
        {
            _CourseRepository = CourseRepository;
        }

        public int Delete(int id)
        {
            var CourseToDelete = _CourseRepository.GetById(id);
            return _CourseRepository.Delete(CourseToDelete);
        }

        public IEnumerable<CourseDTO> GetAll()
        {
            var Course = _CourseRepository.GetAll();

            return Course.Select(c => Mapper.CourseToDTO(c));
        }

        public CourseDTO GetById(int id)
        {
            var Course = _CourseRepository.GetById(id);
            return Mapper.CourseToDTO(Course);
        }

        public int Post(CourseDTO CourseDTO)
        {
            return _CourseRepository.Post(Mapper.CourseFromDTO(CourseDTO));
        }

        public CourseDTO Put(CourseDTO CourseDTO)
        {
            var CourseToUpdate = Mapper.CourseFromDTO(CourseDTO);
            return Mapper.CourseToDTO(_CourseRepository.Put(CourseToUpdate));
        }
    }
}
