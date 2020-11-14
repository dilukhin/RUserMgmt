using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorUserMgmt.Models;

namespace RUserMgmt.Data
{
    public class RUserMgmtContext : DbContext
    {
        public RUserMgmtContext (DbContextOptions<RUserMgmtContext> options)
            : base(options)
        {
        }

        public DbSet<RazorUserMgmt.Models.User> Users { get; set; }
        public DbSet<RazorUserMgmt.Models.Role> Roles { get; set; }
        public DbSet<RazorUserMgmt.Models.UsersRoles> UsersRoles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Role>().ToTable("Role");
            modelBuilder.Entity<UsersRoles>().ToTable("UsersRoles")
                .HasKey(c => new { c.RoleId, c.UserId });
        }
    }
}
