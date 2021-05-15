using CollegeSystem.DataModels.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollegeSystem.Models
{
    public class StudentRequestModel
    {
        public int StudentNumberID { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string MobilePhone { get; set; }
        public List<int> Subjects { get; set; }
    }
}
