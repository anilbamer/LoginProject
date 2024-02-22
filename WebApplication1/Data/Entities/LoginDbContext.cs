using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Data.Entities;

public partial class LoginDbContext : DbContext
{
    public LoginDbContext()
    {
    }

    public LoginDbContext(DbContextOptions<LoginDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Table1> Table1s { get; set; }

    public virtual DbSet<Table2> Table2s { get; set; }

    public virtual DbSet<Table3> Table3s { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=74.235.200.211;Database=login_Db;User Id=njdbserver; Password=njuser@12345;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Table1>(entity =>
        {
            entity.HasKey(e => e.UserId);

            entity.ToTable("Table1");

            entity.Property(e => e.UserId).HasColumnName("userId");
            entity.Property(e => e.Password)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("password");
            entity.Property(e => e.Username)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("username");
        });

        modelBuilder.Entity<Table2>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Table2");

            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(20)
                .IsFixedLength()
                .HasColumnName("firstName");
            entity.Property(e => e.LastName)
                .HasMaxLength(20)
                .IsFixedLength()
                .HasColumnName("lastName");
            entity.Property(e => e.PhoneNumber).HasColumnName("phoneNumber");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.User).WithMany()
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Table2_Table1");
        });

        modelBuilder.Entity<Table3>(entity =>
        {
            entity.ToTable("Table_3");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("email");
            entity.Property(e => e.Firstname)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("firstname");
            entity.Property(e => e.Lastname)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("lastname");
            entity.Property(e => e.Phonenumber).HasColumnName("phonenumber");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
