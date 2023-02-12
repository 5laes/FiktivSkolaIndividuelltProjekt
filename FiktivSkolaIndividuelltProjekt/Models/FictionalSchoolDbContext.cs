using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FiktivSkolaIndividuelltProjekt.Models
{
    public partial class FictionalSchoolDbContext : DbContext
    {
        public FictionalSchoolDbContext()
        {
        }

        public FictionalSchoolDbContext(DbContextOptions<FictionalSchoolDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ClassYear> ClassYears { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Grade> Grades { get; set; } = null!;
        public virtual DbSet<Proffession> Proffessions { get; set; } = null!;
        public virtual DbSet<SetGrade> SetGrades { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<Subject> Subjects { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source = CLAES;Initial Catalog=FiktivSkolaIndividuell;Integrated Security = True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClassYear>(entity =>
            {
                entity.ToTable("ClassYear");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ClassYear1)
                    .HasMaxLength(50)
                    .HasColumnName("ClassYear");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DateOfEmployment).HasColumnType("date");

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.ProffessionId).HasColumnName("ProffessionID");

                entity.Property(e => e.Salary).HasColumnType("money");

                entity.HasOne(d => d.Proffession)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.ProffessionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_Proffession");
            });

            modelBuilder.Entity<Grade>(entity =>
            {
                entity.ToTable("Grade");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Grade1)
                    .HasMaxLength(50)
                    .HasColumnName("Grade");
            });

            modelBuilder.Entity<Proffession>(entity =>
            {
                entity.ToTable("Proffession");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ProffessionName).HasMaxLength(50);
            });

            modelBuilder.Entity<SetGrade>(entity =>
            {
                entity.ToTable("SetGrade");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.GradeId).HasColumnName("GradeID");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.SubjectId).HasColumnName("SubjectID");

                entity.Property(e => e.TimeOfGrade).HasColumnType("date");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.SetGrades)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Grade_Employee");

                entity.HasOne(d => d.Grade)
                    .WithMany(p => p.SetGrades)
                    .HasForeignKey(d => d.GradeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SetGrade_Grade");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.SetGrades)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Grade_Student");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.SetGrades)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Grade_Subject");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ClassYearId).HasColumnName("ClassYearID");

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.HasOne(d => d.ClassYear)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.ClassYearId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Student_ClassYear");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.ToTable("Subject");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.SubjectName).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
