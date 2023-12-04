using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace StudentDbcode.Models;

public partial class SampleDbContext : DbContext
{
    public SampleDbContext()
    {
    }

    public SampleDbContext(DbContextOptions<SampleDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblCountry> TblCountries { get; set; }

    public virtual DbSet<TblGender> TblGenders { get; set; }

    public virtual DbSet<TblIdtype> TblIdtypes { get; set; }

    public virtual DbSet<TblStudent> TblStudents { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-BEIV6SH\\MSSQLSERVER16;Database=SampleDB;User ID=sa;Password=111;trustservercertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblCountry>(entity =>
        {
            entity.HasKey(e => e.CountryId).HasName("PK__tblCount__10D160BF57F2DAED");

            entity.ToTable("tblCountry");

            entity.Property(e => e.CountryId)
                .ValueGeneratedNever()
                .HasColumnName("CountryID");
            entity.Property(e => e.CountryName).HasMaxLength(255);
            entity.Property(e => e.IsActive).HasColumnName("isActive");
        });

        modelBuilder.Entity<TblGender>(entity =>
        {
            entity.HasKey(e => e.GenderId).HasName("PK__tblGende__4E24E817571E227A");

            entity.ToTable("tblGender");

            entity.Property(e => e.GenderId)
                .ValueGeneratedNever()
                .HasColumnName("GenderID");
            entity.Property(e => e.Gender).HasMaxLength(50);
            entity.Property(e => e.IsActive).HasColumnName("isActive");
        });

        modelBuilder.Entity<TblIdtype>(entity =>
        {
            entity.HasKey(e => e.IdtypeId).HasName("PK__tbl_IDTy__3B6BCFA7F7E959E4");

            entity.ToTable("tbl_IDType");

            entity.Property(e => e.IdtypeId)
                .ValueGeneratedNever()
                .HasColumnName("IDTypeID");
            entity.Property(e => e.Idtype)
                .HasMaxLength(255)
                .HasColumnName("IDType");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
        });

        modelBuilder.Entity<TblStudent>(entity =>
        {
            entity.HasKey(e => e.StudentGid).HasName("PK__tblStude__BCF7ACADF87B2EA3");

            entity.ToTable("tblStudent");

            entity.Property(e => e.StudentGid)
                .HasMaxLength(50)
                .HasColumnName("StudentGID");
            entity.Property(e => e.FullAddress).HasMaxLength(500);
            entity.Property(e => e.Idnumber)
                .HasMaxLength(50)
                .HasColumnName("IDNumber");
            entity.Property(e => e.Idtype).HasColumnName("IDType");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.MDate).HasColumnName("mDate");
            entity.Property(e => e.MDateTime)
                .HasColumnType("datetime")
                .HasColumnName("mDateTime");
            entity.Property(e => e.Phone).HasMaxLength(50);
            entity.Property(e => e.StudentName).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
