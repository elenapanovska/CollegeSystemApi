using AutoMapper;
using CollegeSystem.DataModels.Models;
using CollegeSystem.Models;
using CollegeSystem.Repositories;
using CollegeSystem.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;

namespace CollegeSystem.Services
{
    public class StudentService : IStudentService
    {
        private readonly IRepository<Student> _studentRepository;
        private readonly IRepository<Subject> _subjectRepository;

        public StudentService(IRepository<Student> studentRepository, IRepository<Subject> subjectRepository)
        {
            _studentRepository = studentRepository;
            _subjectRepository = subjectRepository;
        }

        public IEnumerable<Student> GetStudents()
        {
            return _studentRepository.GetAll();
        }

        public void AddStudent(StudentRequestModel studentRequestModel)
        {
            if (studentRequestModel == null)
                throw new Exception("Request model data not valid");

            string email = studentRequestModel.Email;
            Regex emailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match emailMatch = emailRegex.Match(email);

            if (!emailMatch.Success)
                throw new Exception("Mail is not valid");

            string mobile = studentRequestModel.MobilePhone;
            Regex mobileRegex = new Regex(@"^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\s\./0-9]*$");
            Match mobileMatch = mobileRegex.Match(mobile);

            if (!mobileMatch.Success)
                throw new Exception("Mobile number is not valid");

            if (string.IsNullOrEmpty(studentRequestModel.FullName))
                throw new Exception("Full name can not be empty");

            if (studentRequestModel.Subjects.Count < 2)
            {
                throw new Exception("At least two subjects need to be added!");
            };

            var subjectList = _subjectRepository.GetByIds(studentRequestModel.Subjects).ToList();

            var student = new Student()
            {
                FullName = studentRequestModel.FullName,
                Email = studentRequestModel.Email,
                MobilePhone = studentRequestModel.MobilePhone,
                Subjects = subjectList
            };

            _studentRepository.Insert(student);
        }

        public void AddSubjectToStudent(int studentID, List<int> subjectIds)
        {
            var student = _studentRepository.GetById(studentID);
            var subjects = _subjectRepository.GetByIds(subjectIds);

            foreach (var subject in subjects)
            {
                student.Subjects.Add(subject);
            };

            _studentRepository.Update(student);
        }

        public void UpdateStudent(StudentRequestModel studentRequestModel, int id)
        {
            var student = _studentRepository.GetById(id);

            if (studentRequestModel == null)
                throw new Exception("Request model data not valid");

            string email = studentRequestModel.Email;
            Regex emailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match emailMatch = emailRegex.Match(email);

            if (!emailMatch.Success)
                throw new Exception("Mail is not valid");

            string mobile = studentRequestModel.MobilePhone;
            Regex mobileRegex = new Regex(@"^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\s\./0-9]*$");
            Match mobileMatch = mobileRegex.Match(mobile);

            if (!mobileMatch.Success)
                throw new Exception("Mobile number is not valid");

            if (string.IsNullOrEmpty(studentRequestModel.FullName))
                throw new Exception("Full name can not be empty");

            student.FullName = studentRequestModel.FullName;
            student.Email = studentRequestModel.Email;
            student.MobilePhone = studentRequestModel.MobilePhone;

            _studentRepository.Update(student);
        }

        public void DeleteStudent(int id)
        {
            var student = _studentRepository.GetById(id);
            _studentRepository.Delete(student);
        }


    }
}
