using Kundalik.Uz.Data;
using Kundalik.Uz.Models;
using Microsoft.EntityFrameworkCore;

namespace Kundalik.Uz.Services
{
    class StudentsService
    {
        private readonly KundalikDbContext _context;

        public StudentsService()
        {
            _context = new KundalikDbContext();
        }

        public List<Student> GetStudents()
        {
            var students = _context.Students.ToList();

            return students;
        } 
    }
}
