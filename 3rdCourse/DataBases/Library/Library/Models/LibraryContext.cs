using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Library.Models
{
    public partial class LibraryContext : DbContext
    {
        public LibraryContext()
        {
        }
        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Book> Books { get; set; } = null!;
        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<Faculty> Faculties { get; set; } = null!;
        public virtual DbSet<Group> Groups { get; set; } = null!;
        public virtual DbSet<Lib> Libs { get; set; } = null!;
        public virtual DbSet<Librarian> Librarians { get; set; } = null!;
        public virtual DbSet<SCard> SCards { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<TCard> TCards { get; set; } = null!;
        public virtual DbSet<Teacher> Teachers { get; set; } = null!;
        public virtual DbSet<Admin> Admins { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Officer> Officers { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer("Server=LAPTOP-P14D9V4Q;Database=Library;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entity =>
            {
                entity.Property(e => e.Comment).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Theme).HasMaxLength(100);

                entity.Property(e => e.Category).HasMaxLength(100);

                entity.Property(e => e.Author).HasMaxLength(100);

                entity.Property(e => e.Press).HasMaxLength(100);

                entity.HasOne(d => d.IdLibNavigation)
                  .WithMany(p => p.Books)
                  .HasForeignKey(d => d.Id_Lib)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_Books_Lib");

            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(40);
            });

            modelBuilder.Entity<Faculty>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(40);
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.Property(e => e.Id_Faculty).HasColumnName("Id_Faculty");

                entity.Property(e => e.Name).HasMaxLength(40);

                entity.HasOne(d => d.IdFacultyNavigation)
                    .WithMany(p => p.Groups)
                    .HasForeignKey(d => d.Id_Faculty)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Groups_Faculty");
            });

            modelBuilder.Entity<Lib>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Librarian>(entity =>
            {
                entity.Property(e => e.FirstName).HasMaxLength(25);

                entity.Property(e => e.LastName).HasMaxLength(35);

                entity.HasOne(d => d.IdLibNavigation)
                  .WithMany(p => p.Librarians)
                  .HasForeignKey(d => d.Id_Lib)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_Librarians_Lib");
            });

            modelBuilder.Entity<SCard>(entity =>
            {
                entity.ToTable("S_Cards");

                entity.Property(e => e.DateIn).HasColumnType("datetime");

                entity.Property(e => e.DateOut).HasColumnType("datetime");

                entity.Property(e => e.Id_Book).HasColumnName("Id_Book");

                entity.Property(e => e.Id_Librarian).HasColumnName("Id_Librarian");

                entity.Property(e => e.Id_Lib).HasColumnName("Id_Lib");

                entity.Property(e => e.Id_Student).HasColumnName("Id_Student");

                entity.HasOne(d => d.IdBookNavigation)
                    .WithMany(p => p.SCards)
                    .HasForeignKey(d => d.Id_Book)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_S_Cards_Book");

                entity.HasOne(d => d.IdLibNavigation)
                .WithMany(p => p.SCards)
                .HasForeignKey(d => d.Id_Lib)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_S_Cards_Lib");

                entity.HasOne(d => d.IdLibrarianNavigation)
                    .WithMany(p => p.SCards)
                    .HasForeignKey(d => d.Id_Librarian)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_S_Cards_Libr");

                entity.HasOne(d => d.IdStudentNavigation)
                    .WithMany(p => p.SCards)
                    .HasForeignKey(d => d.Id_Student)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_S_Cards_Stud");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.FirstName).HasMaxLength(25);

                entity.Property(e => e.Id_Group).HasColumnName("Id_Group");

                entity.Property(e => e.LastName).HasMaxLength(35);

                entity.HasOne(d => d.IdGroupNavigation)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.Id_Group)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Students_Group");
            });

            modelBuilder.Entity<TCard>(entity =>
            {
                entity.ToTable("T_Cards");

                entity.Property(e => e.DateIn).HasColumnType("datetime");

                entity.Property(e => e.DateOut).HasColumnType("datetime");

                entity.Property(e => e.Id_Book).HasColumnName("Id_Book");

                entity.Property(e => e.Id_Librarian).HasColumnName("Id_Librarian");

                entity.Property(e => e.Id_Lib).HasColumnName("Id_Lib");

                entity.Property(e => e.Id_Teacher).HasColumnName("Id_Teacher");

                entity.HasOne(d => d.IdBookNavigation)
                    .WithMany(p => p.TCards)
                    .HasForeignKey(d => d.Id_Book)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_Cards_Book");

                entity.HasOne(d => d.IdLibNavigation)
                    .WithMany(p => p.TCards)
                    .HasForeignKey(d => d.Id_Lib)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_Cards_Lib");

                entity.HasOne(d => d.IdLibrarianNavigation)
               .WithMany(p => p.TCards)
               .HasForeignKey(d => d.Id_Librarian)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("FK_T_Cards_Libr");

                entity.HasOne(d => d.IdTeacherNavigation)
                    .WithMany(p => p.TCards)
                    .HasForeignKey(d => d.Id_Teacher)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_Cards_Teacher");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.Property(e => e.FirstName).HasMaxLength(25);

                entity.Property(e => e.Id_Dep).HasColumnName("Id_Dep");

                entity.Property(e => e.LastName).HasMaxLength(35);

                entity.HasOne(d => d.IdDepNavigation)
                    .WithMany(p => p.Teachers)
                    .HasForeignKey(d => d.Id_Dep)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Teachers_Dep");
            });

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(45);

                entity.Property(e => e.Password).HasMaxLength(35);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(45);

                entity.Property(e => e.Password).HasMaxLength(35);
            });

            modelBuilder.Entity<Officer>(entity =>
            {
                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(45);

                entity.Property(e => e.Password).HasMaxLength(35);
            });

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
