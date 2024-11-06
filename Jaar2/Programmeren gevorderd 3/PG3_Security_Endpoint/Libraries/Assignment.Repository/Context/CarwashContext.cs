using System;
using System.Collections.Generic;
using Assignment.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment.Repository.Context;

public partial class CarwashContext : DbContext
{
    public CarwashContext()
    {
    }

    public CarwashContext(DbContextOptions<CarwashContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bestellingen> Bestellingens { get; set; }

    public virtual DbSet<Bestellingsregel> Bestellingsregels { get; set; }

    public virtual DbSet<Diensten> Dienstens { get; set; }

    public virtual DbSet<Klanten> Klantens { get; set; }

    public virtual DbSet<Voertuigen> Voertuigens { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultConnectionString");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bestellingen>(entity =>
        {
            entity.HasKey(e => e.BestellingId).HasName("PK__Bestelli__2326A2855070BC68");

            entity.ToTable("Bestellingen");

            entity.Property(e => e.BestellingId).HasColumnName("BestellingID");
            entity.Property(e => e.KlantId).HasColumnName("KlantID");
            entity.Property(e => e.TotaalBedrag).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.VoertuigId).HasColumnName("VoertuigID");

            entity.HasOne(d => d.Klant).WithMany(p => p.Bestellingens)
                .HasForeignKey(d => d.KlantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Bestellin__Klant__3E52440B");

            entity.HasOne(d => d.Voertuig).WithMany(p => p.Bestellingens)
                .HasForeignKey(d => d.VoertuigId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Bestellin__Voert__3F466844");
        });

        modelBuilder.Entity<Bestellingsregel>(entity =>
        {
            entity.HasKey(e => e.BestellingsregelId).HasName("PK__Bestelli__D80E112E65C9A690");

            entity.Property(e => e.BestellingsregelId).HasColumnName("BestellingsregelID");
            entity.Property(e => e.BestellingId).HasColumnName("BestellingID");
            entity.Property(e => e.DienstId).HasColumnName("DienstID");
            entity.Property(e => e.PrijsPerStuk).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.TotaalPrijs).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Bestelling).WithMany(p => p.Bestellingsregels)
                .HasForeignKey(d => d.BestellingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Bestellin__Beste__4222D4EF");

            entity.HasOne(d => d.Dienst).WithMany(p => p.Bestellingsregels)
                .HasForeignKey(d => d.DienstId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Bestellin__Diens__4316F928");
        });

        modelBuilder.Entity<Diensten>(entity =>
        {
            entity.HasKey(e => e.DienstId).HasName("PK__Diensten__509D81CBB819BC83");

            entity.ToTable("Diensten");

            entity.Property(e => e.DienstId).HasColumnName("DienstID");
            entity.Property(e => e.Beschrijving).HasMaxLength(500);
            entity.Property(e => e.Naam).HasMaxLength(100);
            entity.Property(e => e.Prijs).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<Klanten>(entity =>
        {
            entity.HasKey(e => e.KlantId).HasName("PK__Klanten__A2633BE2E3A27848");

            entity.ToTable("Klanten");

            entity.Property(e => e.KlantId).HasColumnName("KlantID");
            entity.Property(e => e.Adres).HasMaxLength(200);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Naam).HasMaxLength(100);
            entity.Property(e => e.Telefoon).HasMaxLength(15);
        });

        modelBuilder.Entity<Voertuigen>(entity =>
        {
            entity.HasKey(e => e.VoertuigId).HasName("PK__Voertuig__ABAE50DBD62054A4");

            entity.ToTable("Voertuigen");

            entity.Property(e => e.VoertuigId).HasColumnName("VoertuigID");
            entity.Property(e => e.Kenteken).HasMaxLength(20);
            entity.Property(e => e.KlantId).HasColumnName("KlantID");
            entity.Property(e => e.Merk).HasMaxLength(50);
            entity.Property(e => e.Model).HasMaxLength(50);

            entity.HasOne(d => d.Klant).WithMany(p => p.Voertuigens)
                .HasForeignKey(d => d.KlantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Voertuige__Klant__398D8EEE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
