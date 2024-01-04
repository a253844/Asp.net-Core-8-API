using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BlockAction.Repository.Dtos.DataModel;

public partial class DemodbContext : DbContext
{
    public DemodbContext()
    {
    }

    public DemodbContext(DbContextOptions<DemodbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Userdatainfo> Userdatainfos { get; set; }

    public virtual DbSet<Userfundetail> Userfundetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Demodb;Username=postgres;Password=1qaz2wsx");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Userdatainfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("userinfo_pkey");

            entity.ToTable("userdatainfo");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("nextval('userfundetail_id_seq'::regclass)")
                .HasColumnName("id");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Money)
                .HasColumnType("money")
                .HasColumnName("money");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Tag).HasColumnName("tag");
        });

        modelBuilder.Entity<Userfundetail>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.CreateTime }).HasName("userfundetail_pkey");

            entity.ToTable("userfundetail");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.AfterBalance).HasColumnType("money");
            entity.Property(e => e.BeforeBalance).HasColumnType("money");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
