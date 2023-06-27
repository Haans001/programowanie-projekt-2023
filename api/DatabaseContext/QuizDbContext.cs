using api.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace api.DatabaseContext;

public class QuizDbContext : DbContext
{
    public QuizDbContext(DbContextOptions opt) : base(opt)
    {
        
    }
    
    public DbSet<Score> Scores { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Class> Classes { get; set; }
    public DbSet<Quiz> Quizzes { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Answer> Answers { get; set; }
    public DbSet<Role> Roles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Class>().HasMany(x => x.Users).WithMany(y => y.Classes)
            .UsingEntity(j => j.ToTable("ClassUser"));
        
        
        modelBuilder.Entity<User>(opt =>
        {
            opt.Property(a => a.Email).HasMaxLength(50);
            opt.Property(a => a.Password).HasColumnName("PasswordHash").HasMaxLength(150);
            opt.Property(a => a.FirstName).HasMaxLength(50);
            opt.Property(a => a.LastName).HasMaxLength(50);
        });
        modelBuilder.Entity<Score>(opt =>
        {
            opt.Property(a => a.PercentOfCorrectAnswers).HasPrecision(5, 2);
        });
        modelBuilder.Entity<Role>(opt =>
        {
            opt.Property(r => r.Name).HasMaxLength(50)
                .IsRequired();
        });
        
        modelBuilder.Entity<Quiz>(opt =>
        {
            opt.Property(q => q.Name).HasMaxLength(50);
        });
        modelBuilder.Entity<Question>(opt =>
        {
            opt.Property(q => q.Contents).HasMaxLength(50);
        });
        modelBuilder.Entity<Answer>(opt =>
        {
            opt.Property(a => a.Content).HasMaxLength(50);
        });
        modelBuilder.Entity<Class>(opt =>
        {
            opt.Property(c => c.Description).HasMaxLength(50);
            opt.Property(c => c.Name).HasMaxLength(50);
        });
    }
}