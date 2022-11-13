using Microsoft.EntityFrameworkCore;

namespace MeetingCard.Data.Model
{
    /// <summary>
    /// Фальшивый DataContext
    /// </summary>
    public class ResDbContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Monograph> Monographs { get; set; }
        public DbSet<Presentation> Presentations { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Researcher> Researchers { get; set; }

        public ResDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Researcher>()
                .HasMany(g => g.Articles)
                .WithOne(s => s.Researcher)
                .HasForeignKey(e => e.ResearcherId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Researcher>()
                .HasMany(g => g.Monographs)
                .WithOne(s => s.Researcher)
                .HasForeignKey(e => e.ResearcherId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Researcher>()
                .HasMany(g => g.Presentations)
                .WithOne(s => s.Researcher)
                .HasForeignKey(e => e.ResearcherId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Researcher>()
                .HasMany(g => g.Reports)
                .WithOne(s => s.Researcher)
                .HasForeignKey(e => e.ResearcherId)
                .OnDelete(DeleteBehavior.Cascade);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("X");

        }
    }
}