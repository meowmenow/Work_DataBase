using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataBaseHell.Models;

public partial class AboltusContext : DbContext
{
    public AboltusContext()
    {
    }

    public AboltusContext(DbContextOptions<AboltusContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Abonent> Abonents { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost\\sqlexpress; Database=Aboltus; User=исп-43; Password=1234567890; Encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Abonent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Abonents__3213E83F33B4DB92");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Age).HasColumnType("datetime");
            entity.Property(e => e.Fio)
                .HasMaxLength(50)
                .HasColumnName("FIO");
            entity.Property(e => e.Gender).HasMaxLength(7);
            entity.Property(e => e.Inn)
                .HasMaxLength(12)
                .HasColumnName("INN");
            entity.Property(e => e.Phone).HasMaxLength(10);
            entity.Property(e => e.Photo).HasColumnType("image");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
