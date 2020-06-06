using Microsoft.EntityFrameworkCore;

namespace Codenation.Challenge.Models
{
    public class CodenationContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Challenge> Challenges { get; set; }

        public DbSet<Company> Companies { get; set; }

        public DbSet<Acceleration> Accelerations { get; set; }

        public DbSet<Submission> Submissions { get; set; }

        public DbSet<Candidate> Candidates { get; set; }

        public CodenationContext()
        {
            Database.BeginTransaction();
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Codenation;Trusted_Connection=True");            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Submission>()
                .HasKey(s => new { s.Id, s.Challenge_Id });

            modelBuilder.Entity<Submission>()
                .HasOne(u => u.User)
                .WithMany(s => s.Submissions)
                .HasForeignKey(u => u.Id);

            modelBuilder.Entity<Submission>()
                .HasOne(c => c.Challenge)
                .WithMany(s => s.Submissions)
                .HasForeignKey(c => c.Challenge_Id);

            modelBuilder.Entity<Acceleration>()
                .HasOne(a => a.Challenge)
                .WithMany(c => c.Accelerations)
                .HasForeignKey(c => c.Challenge_Id);

            modelBuilder.Entity<Candidate>()
                .HasKey(c => new { c.Acceleration_Id, c.Id, c.Company_Id });

            modelBuilder.Entity<Candidate>()
                .HasOne(c => c.Acceleration)
                .WithMany(a => a.Candidates)
                .HasForeignKey(a => a.Acceleration_Id);

            modelBuilder.Entity<Candidate>()
                .HasOne(c => c.User)
                .WithMany(u => u.Candidates)
                .HasForeignKey(u => u.Id);

            modelBuilder.Entity<Candidate>()
                .HasOne(c => c.Company)
                .WithMany(c => c.Candidates)
                .HasForeignKey(c => c.Company_Id);
        }
    }
}