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
    public class ClassRoomBL : IClassRoomBL
    {
        private readonly IClassRoomRepository _classRoomRepository;

        public ClassRoomBL(IClassRoomRepository classRoomRepository)
        {
            _classRoomRepository = classRoomRepository;
        }

        public int Delete(int id)
        {
            var ClassRoomToDelete = _classRoomRepository.GetById(id);
            return _classRoomRepository.Delete(ClassRoomToDelete);
        }

        public IEnumerable<ClassRoomDTO> GetAll()
        {
            var classRoom = _classRoomRepository.GetAll();

            return classRoom.Select(c => Mapper.ClassRoomToDTO(c));
        }

        public ClassRoomDTO GetById(int id)
        {
            var classRoom =_classRoomRepository.GetById(id);
            return Mapper.ClassRoomToDTO(classRoom);
        }

        public int Post(ClassRoomDTO classRoomDTO)
        {
            return _classRoomRepository.Post(Mapper.ClassRoomFromDTO(classRoomDTO));
        }

        public ClassRoomDTO Put(ClassRoomDTO classRoomDTO)
        {
            var classRoomToUpdate = Mapper.ClassRoomFromDTO(classRoomDTO);
            return Mapper.ClassRoomToDTO(_classRoomRepository.Put(classRoomToUpdate)); 
        }
    }
}
