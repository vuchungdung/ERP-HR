using Database.Sql.ERP.Entities.Cadidate;
using Database.Sql.ERP.Entities.Common;
using Database.Sql.ERP.Entities.Interview;
using Database.Sql.ERP.Entities.Recruitment;
using Database.Sql.ERP.Entities.System;
using Database.Sql.ERP.Entities.System.System;
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

            builder.Entity<InterviewProcess>()
                        .HasKey(c => new { c.CadidateId, c.ProcessId });

            builder.Entity<UserRole>()
                        .HasKey(c => new { c.UserId, c.RoleId });

            builder.Entity<CommandInFunction>()
                       .HasKey(c => new { c.CommandId, c.FunctionId });

            builder.HasSequence("ERPSequence");
        }
        public DbSet<CommandInFunction> CommandInFunctions { get; set; }
        public DbSet<Cadidate> Cadidates { get; set; }
        public DbSet<CadidateApplyHistory> CadidateApplyHistories { get; set; }
        public DbSet<FileCV> FileCVs { get; set; }
        public DbSet<JobCategory> JobCategories { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<InterviewDate> InterviewDates { get; set; }
        public DbSet<InterviewProcess> InterviewProcess { get; set; }
        public DbSet<InterviewResult> InterviewResults { get; set; }
        public DbSet<Process> Process { get; set; }
        public DbSet<JobDescription> JobDescriptions { get; set; }
        public DbSet<RecruitmentPlan> RecruitmentPlans { get; set; }
        public DbSet<Command> Commands { set; get; }
        public DbSet<Function> Functions { set; get; }
        public DbSet<Permission> Permissions { set; get; }
        public DbSet<User> Users { set; get; }
        public DbSet<UserRole> UserRoles { set; get; }
        public DbSet<Role> Roles { set; get; }
    }
}
