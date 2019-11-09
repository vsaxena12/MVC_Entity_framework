using LeaveManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagementSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<Leave> leave { get; set; }
        public DbSet<LeaveType> leavetype { get; set; }
        public DbSet<UserTable> usertable { get; set; }
    }
    
}
