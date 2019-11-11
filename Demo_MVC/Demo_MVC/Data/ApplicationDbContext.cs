using Demo_MVC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo_MVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }

        public DbSet<Users> users { get; set; }
        public DbSet<LeaveTypeClass> leaveTypeClass { get; set; }
        public DbSet<Leaves> leaves { get; set; }

    }
}
