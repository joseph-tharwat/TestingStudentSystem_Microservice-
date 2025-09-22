using Microsoft.EntityFrameworkCore;
using TestManagment.Domain.Entities;

namespace TestManagment.Infrastructure
{
    public class TestDbContext: DbContext
    {
        public DbSet<Question> Questions { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<TestsScheduling> TestsScheduling { get; set; }
        public DbSet<TestQuestion> TestsQuestions { get; set; }

        public TestDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Question>()
                .HasKey(q => q.Id);

            modelBuilder.Entity<Test>()
                .HasKey(t => t.Id);

            modelBuilder.Entity<TestsScheduling>()
                .HasKey(t => new {t.TestId, t.DateTime});

            modelBuilder.Entity<TestQuestion>()
                .HasKey(t => new { t.TestId, t.QuestionId });

            modelBuilder.Entity<Test>()
                .HasMany(t => t.TestQuestions)
                .WithOne(tq => tq.Test)
                .HasForeignKey(tq=>tq.TestId);

            modelBuilder.Entity<Question>()
                .HasMany(q => q.TestQuestions)
                .WithOne(tq => tq.question)
                .HasForeignKey(tq=>tq.QuestionId);

            modelBuilder.Entity<Test>()
                .HasMany(t => t.Schedulings)
                .WithOne(s => s.test)
                .HasForeignKey(s => s.TestId);

            modelBuilder.UseHiLo();

        }
    }
}
