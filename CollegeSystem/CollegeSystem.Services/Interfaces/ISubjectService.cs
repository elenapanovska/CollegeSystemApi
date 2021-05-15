using CollegeSystem.DataModels.Models;
using CollegeSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollegeSystem.Services.Interfaces
{
    public interface ISubjectService
    {
        IEnumerable<Subject> GetSubjects();
        void AddSubject(SubjectRequestModel requestModel);
        void UpdateSubject(SubjectRequestModel requestModel, int subjectId);
        void DeleteSubject(int id);
        
    }
}
