using LeaveManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagement.Data
{
        public class ApplicationDbContext : DbContext
        {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
            {

            }
            public DbSet<Leave> leave { get; set; }
            public DbSet<LeaveTypeClass> leaveTypeClass { get; set; }
            public DbSet<User> user { get; set; }
        public IEnumerable Users { get; internal set; }
    }
}

