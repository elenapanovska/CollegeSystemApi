using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CollegeSystem.DataModels.Models
{
    public class Subject
    {
        public int SubjectID { get; set; }
        public string Name { get; set; }
        public int Credits { get; set; }
        public int Semester { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
