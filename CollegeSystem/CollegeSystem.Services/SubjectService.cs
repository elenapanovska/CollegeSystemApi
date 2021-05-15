using AutoMapper;
using CollegeSystem.DataModels.Models;
using CollegeSystem.Models;
using CollegeSystem.Repositories;
using CollegeSystem.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CollegeSystem.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly IRepository<Subject> _subjectRepository;


        public SubjectService(IRepository<Subject> subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }

        public IEnumerable<Subject> GetSubjects()
        {
            return _subjectRepository.GetAll();
        }

        public void AddSubject(SubjectRequestModel subjectRequest)
        {
            if(subjectRequest == null)
                throw new Exception("Request model data not valid!");
            
            if (string.IsNullOrEmpty(subjectRequest.Name))
                throw new Exception("Subject name is requried!");
            
            if(subjectRequest.Semester == 0)
                throw new Exception("Semester can not be 0");
            
            if(subjectRequest.Credits == 0)
                throw new Exception("Credints can not to be 0");

            var subject = new Subject()
            {
                Name = subjectRequest.Name,
                Credits = subjectRequest.Credits,
                Semester = subjectRequest.Semester
            };

            _subjectRepository.Insert(subject);
        }

        public void UpdateSubject(SubjectRequestModel subjectRequest, int id)
        {
            var subject = _subjectRepository.GetById(id);

            if (subjectRequest == null)
                throw new Exception("Request model data not valid!");

            if (!string.IsNullOrEmpty(subjectRequest.Name))
                throw new Exception("Subject name is requried!");

            if (subjectRequest.Semester == 0)
                throw new Exception("Semester can not be 0");

            if (subjectRequest.Credits == 0)
                throw new Exception("Credints can not to be 0");

            subject.Name = subjectRequest.Name;
            subject.Credits = subjectRequest.Credits;
            subject.Semester = subjectRequest.Semester;

            _subjectRepository.Update(subject);
        }

       
        public void DeleteSubject(int id)
        {
            var subject = _subjectRepository.GetById(id);
            _subjectRepository.Delete(subject);
        }
    }
}
