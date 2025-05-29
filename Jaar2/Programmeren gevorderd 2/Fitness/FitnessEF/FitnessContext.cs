﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessBL.Model;
using FitnessEF.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FitnessEF
{
    public class FitnessContext : DbContext
    {
        public DbSet<MemberEF> members { get; set; }
        public DbSet<ProgramEF> program { get; set; }
        public DbSet<ReservationEF> reservation { get; set; }
        public DbSet<Time_slotEF> time_slot { get; set; }
        public DbSet<EquipmentEF> equipment { get; set; }
        public DbSet<Runningsession_mainEF> runningsession_main { get; set; }
        public DbSet<Runningsession_detailEF> runningsession_detail { get; set; }

        public DbSet<CyclingSessionEF> cyclingsession { get; set; }

        private string connectionString;

        public FitnessContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the many-to-many relationship
            modelBuilder
                .Entity<ProgramEF>()
                .HasMany(p => p.Members)
                .WithMany(m => m.Programs)
                .UsingEntity<Dictionary<string, object>>(
                    "ProgramMember", // Name of the join table
                    j => j.HasOne<MemberEF>().WithMany().HasForeignKey("member_id"), // Foreign key column name for Member
                    j => j.HasOne<ProgramEF>().WithMany().HasForeignKey("programCode"), // Foreign key column name for Program
                    j =>
                    {
                        j.ToTable("programmembers"); // Rename the join table to 'programmembers'
                    }
                );

            modelBuilder
                .Entity<Runningsession_detailEF>()
                .HasKey(rs => new { rs.runningsession_id, rs.seq_nr }); // Definieer samengestelde sleutel

            // Samengestelde sleutel configureren
            modelBuilder
                .Entity<ReservationEF>()
                .HasKey(r => new
                {
                    r.reservation_id,
                    r.time_slot_id,
                    r.equipment_id
                });

            modelBuilder
                .Entity<EquipmentOnderhoudEF>()
                .HasOne(eo => eo.Equipment) // Elke onderhoudsbeurt heeft één apparaat
                .WithOne() // Elk apparaat kan maximaal één onderhoudsbeurt hebben
                .HasForeignKey<EquipmentOnderhoudEF>(eo => eo.equipment_id) // Buitenlandse sleutel naar EquipmentEF
                .OnDelete(DeleteBehavior.Cascade); // Verwijder de onderhoudsbeurt als het bijbehorende apparaat wordt verwijderd

            base.OnModelCreating(modelBuilder);
        }
    }
}
