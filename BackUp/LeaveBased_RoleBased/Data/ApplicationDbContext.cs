using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using LeaveBased_RoleBased.Models;

namespace LeaveBased_RoleBased.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<LeaveBased_RoleBased.Models.LeaveTypes> LeaveTypes { get; set; }
        public DbSet<LeaveBased_RoleBased.Models.Leaves> Leaves { get; set; }
    }
}
