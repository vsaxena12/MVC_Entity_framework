using System;
using System.Collections.Generic;
using System.Text;
using AssessmentSample.Models;
using Microsoft.EntityFrameworkCore;

namespace AssessmentSample.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Department> Department { get; set; }
    }
}