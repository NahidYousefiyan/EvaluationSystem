using EvaluationSystem.Core.Domain.Colleges.Entities;
using EvaluationSystem.Core.Domain.EvaluationForms.Entities;
using EvaluationSystem.Core.Domain.UserEvaluationForms.Entities;
using EvaluationSystem.Core.Domain.Users.Entities;
using Microsoft.EntityFrameworkCore;

namespace EvaluationSystem.Infra.DAL.SQL
{
    public class EvaluationSystemDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserAccessToken> UserAccessTokens  { get; set; }        
        public DbSet<College>Colleges  { get; set; }                           
        public DbSet<EvaluationForm> EvaluationForms  { get; set; }
        public DbSet<EvaluationFormQuestion> FormQuestions  { get; set; }
        public DbSet<EvaluationFormAnswer> FormAnswers  { get; set; }
        public DbSet<UserEvaluationForm> UserEvaluationForms { get; set; }
        public DbSet<UserEvaluationFormDetail> UserEvaluationFormDetails  { get; set; }


        public EvaluationSystemDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer("Password=1;User=sa;Initial Catalog=EvaluationSystemDB;Data Source=.");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
