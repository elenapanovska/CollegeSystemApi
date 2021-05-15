using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CollegeSystem.DataModels.Models
{
    public class Student
    {
        public int StudentNumberID { get; set; }
        public string FullName { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Subject> Subjects { get; set; }
    }
}
