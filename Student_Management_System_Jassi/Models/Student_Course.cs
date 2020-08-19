using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Management_System_Jassi.Models
{
    public class Student_Course
    {
        public int ID { get; set; }
        public string Course_Name { get; set; }
        public List<Student_Admission> Student_Admissions { get; set; }
    }
}
