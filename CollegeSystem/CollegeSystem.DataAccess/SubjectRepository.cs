using CollegeSystem.DataModels;
using CollegeSystem.DataModels.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CollegeSystem.Repositories
{
    public class SubjectRepository : IRepository<Subject>
    {
        private readonly CollegeDbContext _context;

        public SubjectRepository(CollegeDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Subject> GetAll()
        {
            return _context.Subjects.Include(s => s.Students).AsNoTracking();
        }

        public Subject GetById(int id)
        {
            return _context.Subjects
                .Include(s => s.Students)
                .FirstOrDefault(s => s.SubjectID == id);
        }

        public void Insert(Subject entity)
        {
            _context.Subjects.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Subject entity)
        {
            _context.Subjects.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(Subject entity)
        {
            _context.Subjects.Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<Subject> GetByIds(List<int> idsList)
        {
            return _context.Subjects.Where(s => idsList.Contains(s.SubjectID));
        }
    }
}
