using System;
using System.Collections.Generic;
using System.Text;

namespace CollegeSystem.Models
{
    public class SubjectRequestModel
    {
        public int SubjectID { get; set; }
        public string Name { get; set; }
        public int Credits { get; set; }
        public int Semester { get; set; }

        public virtual ICollection<StudentRequestModel> Students { get; set; }
    }
}
