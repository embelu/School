using School.API.Entities;
using School.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.API.Helpers
{
    public class Mapper
    {

        public static ClassRoom ClassRoomFromDTO (ClassRoomDTO classRoomDTO)
        {
            return new ClassRoom()
            {
                Id = classRoomDTO.Id,
                Label = classRoomDTO.Label
            };
        }

        public static ClassRoomDTO ClassRoomToDTO(ClassRoom classRoom)
        {
            return new ClassRoomDTO()
            {
                Id = classRoom.Id,
                Label = classRoom.Label
            };
        }

        public static Course CourseFromDTO(CourseDTO courseDTO)
        {
            return new Course()
            {
                Id = courseDTO.Id,
                Label = courseDTO.Label,
                ClassRoomId = courseDTO.ClassRoomId
            };
        }

        public static CourseDTO CourseToDTO(Course course)
        {
            return new CourseDTO()
            {
                Id = course.Id,
                Label = course.Label,
                ClassRoomId = course.ClassRoomId
            };
        }

        public static Student StudentFromDTO(StudentDTO studentDTO)
        {
            return new Student()
            {
                Id = studentDTO.Id, 
                FirstName = studentDTO.FirstName,
                LastName = studentDTO.LastName
            };
        }

        public static StudentDTO StudentToDTO(Student student)
        {
            return new StudentDTO()
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName
            };
        }
    }
}
