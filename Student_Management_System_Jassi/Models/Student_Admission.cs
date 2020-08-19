using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Management_System_Jassi.Models
{
    public class Student_Admission
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public Student_Course Student_Course { get; set; }
        public Student_Teacher Student_Teacher { get; set; }
    }
}
