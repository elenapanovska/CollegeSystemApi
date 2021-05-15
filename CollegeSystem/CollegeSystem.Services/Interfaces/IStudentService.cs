using CollegeSystem.DataModels.Models;
using CollegeSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollegeSystem.Services.Interfaces
{
    public interface IStudentService
    {
        IEnumerable<Student> GetStudents();
        void AddStudent(StudentRequestModel studentRequestModel) ;
        void AddSubjectToStudent(int studentID, List<int> subjectsIds);
        void UpdateStudent(StudentRequestModel studentRequestModel, int id);
        void DeleteStudent(int id);
    }
}
