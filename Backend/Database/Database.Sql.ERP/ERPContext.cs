using Database.Sql.ERP.Entities.Cadidate;
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

            builder.Entity<InterviewProcess>()
                        .HasKey(c => new { c.CadidateId, c.ProcessId });

            builder.Entity<UserRole>()
                        .HasKey(c => new { c.UserId, c.RoleId });

            builder.Entity<CommandInFunction>()
                       .HasKey(c => new { c.CommandId, c.FunctionId });

            builder.HasSequence<int>("DBSequence")
                              .StartsAt(1).IncrementsBy(1);
            builder.Entity<Cadidate>()
               .Property(x => x.CadidateId)
               .HasDefaultValueSql("NEXT VALUE FOR DBSequence");
        }
        public DbSet<CommandInFunction> CommandInFunctions { get; set; }
        public DbSet<Cadidate> Cadidates { get; set; }
        public DbSet<CadidateApplyHistory> CadidateApplyHistories { get; set; }
        public DbSet<File> FileCVs { get; set; }
        public DbSet<JobCategory> JobCategories { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<InterviewDate> InterviewDates { get; set; }
        public DbSet<InterviewProcess> InterviewProcess { get; set; }
        public DbSet<InterviewResult> InterviewResults { get; set; }
        public DbSet<Process> Process { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<JobDescription> JobDescriptions { get; set; }
        public DbSet<RecruitmentPlan> RecruitmentPlans { get; set; }
        public DbSet<Command> Commands { get; set; }
        public DbSet<Function> Functions { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<CadidateUser> CadidateUsers { get; set; }
    }
}
