﻿using Microsoft.EntityFrameworkCore;

namespace WebApplication10.Models;

public partial class BooksContext : DbContext
{
    public BooksContext()
    {
    }

    public BooksContext(DbContextOptions<BooksContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<BooksNew> BooksNews { get; set; }

    public virtual DbSet<SprFormat> SprFormats { get; set; }

    public virtual DbSet<SprIzd> SprIzds { get; set; }

    public virtual DbSet<SprKategory> SprKategories { get; set; }

    public virtual DbSet<SprThemeTDO> SprThemes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

        var connectionString = configuration.GetConnectionString("DefaultString");
        optionsBuilder.UseSqlServer(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Cyrillic_General_CI_AS");

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.N);

            entity.ToTable("books");

            entity.Property(e => e.N).ValueGeneratedNever();
            entity.Property(e => e.Category).HasMaxLength(255);
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Format).HasMaxLength(255);
            entity.Property(e => e.Izd).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Price).HasColumnType("money");
            entity.Property(e => e.Themes).HasMaxLength(255);
        });

        modelBuilder.Entity<BooksNew>(entity =>
        {
            entity.HasKey(e => e.N);

            entity.ToTable("books_new");

            entity.Property(e => e.N).ValueGeneratedNever();
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.FormatId).HasColumnName("format_id");
            entity.Property(e => e.IzdId).HasColumnName("izd_id");
            entity.Property(e => e.KategoryId).HasColumnName("kategory_id");
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Price).HasColumnType("money");
            entity.Property(e => e.ThemesId).HasColumnName("themes_id");

            entity.HasOne(d => d.Format).WithMany(p => p.BooksNews)
                .HasForeignKey(d => d.FormatId)
                .HasConstraintName("FK_books_new_Spr_format");

            entity.HasOne(d => d.Izd).WithMany(p => p.BooksNews)
                .HasForeignKey(d => d.IzdId)
                .HasConstraintName("FK_books_new_Spr_izd");

            entity.HasOne(d => d.Kategory).WithMany(p => p.BooksNews)
                .HasForeignKey(d => d.KategoryId)
                .HasConstraintName("FK_books_new_Spr_kategory");

            entity.HasOne(d => d.Themes).WithMany(p => p.BooksNews)
                .HasForeignKey(d => d.ThemesId)
                .HasConstraintName("FK_books_new_Spr_themes");
        });

        modelBuilder.Entity<SprFormat>(entity =>
        {
            entity.ToTable("Spr_format");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Format).HasMaxLength(255);
        });

        modelBuilder.Entity<SprIzd>(entity =>
        {
            entity.ToTable("Spr_izd");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Izd).HasMaxLength(255);
        });

        modelBuilder.Entity<SprKategory>(entity =>
        {
            entity.ToTable("Spr_kategory");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Category).HasMaxLength(255);
        });

        modelBuilder.Entity<SprThemeTDO>(entity =>
        {
            entity.ToTable("Spr_themes");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Themes).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
