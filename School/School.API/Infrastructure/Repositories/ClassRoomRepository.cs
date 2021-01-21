using School.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.API.Infrastructure.Repositories
{
    public class ClassRoomRepository : IClassRoomRepository
    {
        private readonly SchoolContext _context;

        public ClassRoomRepository(SchoolContext schoolContext)
        {
            _context = schoolContext;
        }

        public int Delete(ClassRoom classRoom)
        {
            _context.Remove(classRoom);
            _context.SaveChanges();
            return classRoom.Id;
        }

        public IEnumerable<ClassRoom> GetAll()
        {
            return _context.ClassRooms;
        }

        public ClassRoom GetById(int id)
        {
            return _context.ClassRooms.Find(id);
        }

        public int Post(ClassRoom classRoom)
        {
            _context.Add(classRoom);
            _context.SaveChanges();
            return classRoom.Id;
        }

        public ClassRoom Put(ClassRoom classRoom)
        {
            _context.Update(classRoom);
            _context.SaveChanges();
            return classRoom;
        }
    }
}
