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

    public virtual DbSet<TableDatainfo> TableDatainfos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=74.235.200.211;Database=login_Db;User Id=njdbserver; Password=njuser@12345;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TableDatainfo>(entity =>
        {
            entity.ToTable("TableDatainfo");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Password)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("password");
            entity.Property(e => e.Username)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
