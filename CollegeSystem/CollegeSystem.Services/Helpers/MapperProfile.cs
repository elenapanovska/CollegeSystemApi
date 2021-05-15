using AutoMapper;
using CollegeSystem.DataModels.Models;
using CollegeSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollegeSystem.Services.Helpers
{
    public class MapperProfile: Profile
    {
        public MapperProfile()
        {
            CreateMap<Student, StudentRequestModel>().ReverseMap();
            CreateMap<Subject, SubjectRequestModel>().ReverseMap();
        }
    }
}
