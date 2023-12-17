using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Trivia_Stage1.Models;

public partial class TriviaContext : DbContext
{
    public TriviaContext()
    {
    }

    public TriviaContext(DbContextOptions<TriviaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Player> Players { get; set; }

    public virtual DbSet<Question> Questions { get; set; }

    public virtual DbSet<Ranking> Rankings { get; set; }

    public virtual DbSet<StatusQuestion> StatusQuestions { get; set; }

    public virtual DbSet<SubjectQuestion> SubjectQuestions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        //optionsBuilder.LogTo(Console.WriteLine);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Player>(entity =>
        {
            entity.HasKey(e => e.Email).HasName("PK__Player__A9D10535902923E8");

            entity.HasOne(d => d.RankNavigation).WithMany(p => p.Players)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Player__Rank__267ABA7A");
        });

        modelBuilder.Entity<Question>(entity =>
        {
            entity.HasKey(e => e.QuestionId).HasName("PK__Question__0DC06FAC21B566FC");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.Questions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Questions__Creat__2D27B809");

            entity.HasOne(d => d.Status).WithMany(p => p.Questions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Questions__Statu__2E1BDC42");

            entity.HasOne(d => d.SubjectNavigation).WithMany(p => p.Questions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Questions__Subje__2F10007B");
        });

        modelBuilder.Entity<Ranking>(entity =>
        {
            entity.HasKey(e => e.RankId).HasName("PK__Ranking__B37AF87619645B85");

            entity.Property(e => e.RankId).ValueGeneratedNever();
        });

        modelBuilder.Entity<StatusQuestion>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("PK__StatusQu__C8EE20631FD637C1");

            entity.Property(e => e.StatusId).ValueGeneratedNever();
        });

        modelBuilder.Entity<SubjectQuestion>(entity =>
        {
            entity.HasKey(e => e.SubjectId).HasName("PK__SubjectQ__AC1BA3A87C61425E");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
