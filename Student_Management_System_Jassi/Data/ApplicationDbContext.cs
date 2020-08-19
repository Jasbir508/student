using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Student_Management_System_Jassi.Models;

namespace Student_Management_System_Jassi.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student_Course> Student_Courses { get; set; }
        public DbSet<Student_Teacher> Student_Teachers { get; set; }
        public DbSet<Student_Admission> Student_Admissions { get; set; }
    }
}
