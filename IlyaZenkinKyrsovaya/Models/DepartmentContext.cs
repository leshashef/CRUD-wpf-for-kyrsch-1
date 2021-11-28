using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace IlyaZenkinKyrsovaya.Models
{
    public partial class DepartmentContext : DbContext
    {
        public DepartmentContext()
        {
        }

        public DepartmentContext(DbContextOptions<DepartmentContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Chair> Chair { get; set; }
        public virtual DbSet<Chairs> Chairs { get; set; }
        public virtual DbSet<Discipline> Discipline { get; set; }
        public virtual DbSet<MigrationHistory> MigrationHistory { get; set; }
        public virtual DbSet<ReportCard> ReportCard { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<Teacher> Teacher { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-QFHLJ6R;Initial Catalog=Department;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chair>(entity =>
            {
                entity.Property(e => e.DeanFio)
                    .IsRequired()
                    .HasColumnName("DeanFIO")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NameChair)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Chairs>(entity =>
            {
                entity.Property(e => e.DeanFio).HasColumnName("DeanFIO");
            });

            modelBuilder.Entity<Discipline>(entity =>
            {
                entity.Property(e => e.NameDiscipline)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TypeOfControl)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Chair)
                    .WithMany(p => p.Discipline)
                    .HasForeignKey(d => d.ChairId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Disciplin__Chair__3C69FB99");

                entity.HasOne(d => d.LeadingTeacher)
                    .WithMany(p => p.Discipline)
                    .HasForeignKey(d => d.LeadingTeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Disciplin__Leadi__3D5E1FD2");
            });

            modelBuilder.Entity<MigrationHistory>(entity =>
            {
                entity.HasKey(e => new { e.MigrationId, e.ContextKey })
                    .HasName("PK_dbo.__MigrationHistory");

                entity.ToTable("__MigrationHistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ContextKey).HasMaxLength(300);

                entity.Property(e => e.Model).IsRequired();

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<ReportCard>(entity =>
            {
                entity.HasOne(d => d.Discipline)
                    .WithMany(p => p.ReportCard)
                    .HasForeignKey(d => d.DisciplineId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ReportCar__Disci__403A8C7D");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.ReportCard)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ReportCar__Stude__412EB0B6");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.ReportCard)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ReportCar__Teach__4222D4EF");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.AddressStudent)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.MiddleName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.YearOfBirth).HasColumnType("date");

                entity.HasOne(d => d.Chair)
                    .WithMany(p => p.Student)
                    .HasForeignKey(d => d.ChairId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Student__ChairId__398D8EEE");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.Property(e => e.AddressTeacher)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.MiddleName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Post)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.YearOfBirth).HasColumnType("date");

                entity.Property(e => e.YearStartWork).HasColumnType("date");

                entity.HasOne(d => d.Chair)
                    .WithMany(p => p.Teacher)
                    .HasForeignKey(d => d.ChairId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Teacher__ChairId__36B12243");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
