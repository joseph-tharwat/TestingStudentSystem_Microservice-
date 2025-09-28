using GradingManagment.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GradingManagment.Infrastructure.Database
{
    public class GradingDbContext: DbContext
    {
        public GradingDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<QuestionInformation> QuestionInformations {  get; set; }
        public DbSet<StudentGrade> StudentGrades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<QuestionInformation>()
                .HasKey(x => x.QuestionId);

            modelBuilder.Entity<StudentGrade>()
                .HasKey(q => new {  q.QuestionId , q.TestId, q.StudentId});

            modelBuilder.UseHiLo();
        }
    }
}
