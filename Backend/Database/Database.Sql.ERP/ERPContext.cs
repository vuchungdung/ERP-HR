using Database.Sql.ERP.Entities.Candidate;
using Database.Sql.ERP.Entities.Common;
using Database.Sql.ERP.Entities.Interview;
using Database.Sql.ERP.Entities.Recruitment;
using Database.Sql.ERP.Entities.System;
using Microsoft.EntityFrameworkCore;

namespace Database.Sql.ERP
{
    public class ERPContext : DbContext
    {
        public ERPContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Permission>()
                       .HasKey(c => new { c.RoleId, c.FunctionId, c.CommandId });

            
            builder.Entity<UserRole>()
                        .HasKey(c => new { c.UserId, c.RoleId });

            builder.Entity<CommandInFunction>()
                       .HasKey(c => new { c.CommandId, c.FunctionId });
        }
        public DbSet<CommandInFunction> CommandInFunctions { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<WorkHistory> WorkHistories { get; set; }
        public DbSet<Award> Awards { get; set; }

        public DbSet<File> FileCVs { get; set; }
        public DbSet<JobCategory> JobCategories { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<InterviewDate> InterviewDates { get; set; }
        public DbSet<InterviewResult> InterviewResults { get; set; }
        public DbSet<Process> Process { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<JobDescription> JobDescriptions { get; set; }
        public DbSet<Command> Commands { get; set; }
        public DbSet<Function> Functions { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Apply> Applies { get; set; }

        public DbSet<Employee> Employees { get; set; }

    }
}
