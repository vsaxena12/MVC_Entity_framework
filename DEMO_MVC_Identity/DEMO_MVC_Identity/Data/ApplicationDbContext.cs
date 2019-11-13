using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DEMO_MVC_Identity.Models;

namespace DEMO_MVC_Identity.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<DEMO_MVC_Identity.Models.Users> Users { get; set; }
        public DbSet<DEMO_MVC_Identity.Models.LeaveTypeClass> LeaveTypeClass { get; set; }
        public DbSet<DEMO_MVC_Identity.Models.Leaves> Leaves { get; set; }
    }
}
