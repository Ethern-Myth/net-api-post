using Microsoft.EntityFrameworkCore;
using Simple_API_Assessment.Models;

namespace Simple_API_Assessment.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public virtual DbSet<Applicant> Applicants { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Add foreign Key for Skill
            modelBuilder.Entity<Skill>()
             .HasOne(s => s.Applicant)
             .WithMany(a => a.Skills)
             .HasForeignKey(s => s.ApplicantId);

            // Default Seeding Data
            modelBuilder.Entity<Applicant>()
            .HasData(
                new Applicant() { Id = 1, Name = "Victor" }
            );

            modelBuilder.Entity<Skill>()
            .HasData(
                new Skill() { Id = 1, Name = "C#", ApplicantId = 1 },
                new Skill() { Id = 2, Name = "API", ApplicantId = 1 },
                new Skill() { Id = 3, Name = "PostgreSQL", ApplicantId = 1 }
            );
        }
    }
}
