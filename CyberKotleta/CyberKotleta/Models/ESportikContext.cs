using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CyberKotleta.Models;

public partial class ESportikContext : DbContext
{
    public ESportikContext()
    {
    }

    public ESportikContext(DbContextOptions<ESportikContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CyberAthlete> CyberAthletes { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost\\sqlexpress; Database=eSportik; User=исп-43; Password=1234567890; Encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CyberAthlete>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CyberAth__3213E83FFBEF3810");

            entity.ToTable("CyberAthlete");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Adr)
                .HasMaxLength(30)
                .HasColumnName("ADR");
            entity.Property(e => e.BirthDay).HasColumnType("datetime");
            entity.Property(e => e.CoachFio)
                .HasMaxLength(50)
                .HasColumnName("CoachFIO");
            entity.Property(e => e.Country).HasMaxLength(30);
            entity.Property(e => e.CyberFio)
                .HasMaxLength(50)
                .HasColumnName("CyberFIO");
            entity.Property(e => e.Dpr)
                .HasMaxLength(30)
                .HasColumnName("DPR");
            entity.Property(e => e.Gender).HasMaxLength(7);
            entity.Property(e => e.Impact)
                .HasMaxLength(30)
                .HasColumnName("IMPACT");
            entity.Property(e => e.Kast)
                .HasMaxLength(30)
                .HasColumnName("KAST");
            entity.Property(e => e.Kpr)
                .HasMaxLength(30)
                .HasColumnName("KPR");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Role__8AFACE3AD07F6A52");

            entity.ToTable("Role");

            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.RoleName).HasMaxLength(15);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCACF70EC918");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.UserFio)
                .HasMaxLength(50)
                .HasColumnName("UserFIO");
            entity.Property(e => e.UserLogin).HasMaxLength(50);
            entity.Property(e => e.UserPassword).HasMaxLength(50);

            entity.HasOne(d => d.UserRoleNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.UserRole)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Users__UserRole__3B75D760");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
