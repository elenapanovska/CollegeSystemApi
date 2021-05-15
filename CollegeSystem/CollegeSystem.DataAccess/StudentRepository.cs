using CollegeSystem.DataModels;
using CollegeSystem.DataModels.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CollegeSystem.Repositories
{
    public class StudentRepository : IRepository<Student>
    {
        private readonly CollegeDbContext _context;

        public StudentRepository(CollegeDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Student> GetAll()
        {
            return _context.Students.Include(s => s.Subjects).AsNoTracking();
        }

        public Student GetById(int id)
        {
            return _context.Students
                .Include(s => s.Subjects)
                .FirstOrDefault(s => s.StudentNumberID == id);
        }

        public void Insert(Student entity)
        {
            _context.Students.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Student entity)
        {
            _context.Students.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(Student entity)
        {
            _context.Students.Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<Student> GetByIds(List<int> idsList)
        {
            return _context.Students.Where(s => idsList.Contains(s.StudentNumberID));
        }
    }
}
