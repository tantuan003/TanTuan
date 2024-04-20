using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EF.Models
{
    public partial class EFContext : DbContext
    {
        public EFContext()
        {
        }

        public EFContext(DbContextOptions<EFContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Khoa> Khoa { get; set; }
        public virtual DbSet<Lop> Lop { get; set; }
        public virtual DbSet<SinhVien> SinhVien { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-R4TO9PD\\SQLEXPRESS;Initial Catalog=EF;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Khoa>(entity =>
            {
                entity.HasKey(e => e.TenKhoa)
                    .HasName("PK__Khoa__AAD3615939B84C3F");

                entity.Property(e => e.TenKhoa).HasMaxLength(10);
            });

            modelBuilder.Entity<Lop>(entity =>
            {
                entity.HasKey(e => e.TenLop)
                    .HasName("PK__Lop__336AF71FABD9AAF2");

                entity.Property(e => e.TenLop).HasMaxLength(5);
            });

            modelBuilder.Entity<SinhVien>(entity =>
            {
                entity.HasKey(e => e.MaSsv)
                    .HasName("PK__SinhVien__318B19ED7DEC2F52");

                entity.Property(e => e.MaSsv).HasMaxLength(14);

                entity.Property(e => e.Khoa).HasMaxLength(10);

                entity.Property(e => e.Lop).HasMaxLength(5);

                entity.Property(e => e.Ten).HasMaxLength(30);

                entity.HasOne(d => d.KhoaNavigation)
                    .WithMany(p => p.SinhVien)
                    .HasForeignKey(d => d.Khoa)
                    .HasConstraintName("FK__SinhVien__Khoa__619B8048");

                entity.HasOne(d => d.LopNavigation)
                    .WithMany(p => p.SinhVien)
                    .HasForeignKey(d => d.Lop)
                    .HasConstraintName("FK__SinhVien__Lop__60A75C0F");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
