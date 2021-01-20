using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace School.API.Entities
{
    public partial class SchoolContext : DbContext
    {
        public SchoolContext()
        {
        }

        public SchoolContext(DbContextOptions<SchoolContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ClassRoom> ClassRooms { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "French_CI_AS");

            modelBuilder.Entity<ClassRoom>(entity =>
            {
                entity.ToTable("ClassRoom");

                entity.Property(e => e.Label)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("Course");

                entity.Property(e => e.Label)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsFixedLength(true);

                entity.HasOne(d => d.ClassRoom)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.ClassRoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Course_ClassRoom");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsFixedLength(true);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<StudentCourse>(entity =>
            {
                entity.HasKey(e => new { e.StudentId, e.CourseId });

                entity.ToTable("Student_Course");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.StudentCourses)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Student_Course_Course");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentCourses)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Student_Course_Student1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
