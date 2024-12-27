using FitnesDataEF.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnesDataEF
{
    public class FitnessContext : DbContext
    {
        private string connectionString;
        public DbSet<CyclingSessionEF> cyclingsession { get; set; }
        public DbSet<EquipmentEF> equipment { get; set; }
        public DbSet<MemberEF> members { get; set; }
        public DbSet<ProgramEF> program { get; set; }
        public DbSet<ProgramMemberEF> programmembers { get; set; }
        public DbSet<ReservationEF> reservation { get; set; }
        public DbSet<RunningSessionDetailEF> runningsession_detail { get; set; }
        public DbSet<RunningSessionMainEF> runningSession_main { get; set; }
        public DbSet<TimeSlotEF> time_slot { get; set; }

        public FitnessContext(string connectionString)
        {
            this.connectionString = connectionString;
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Configuratie voor ProgramMemberEF
            modelBuilder.Entity<ProgramMemberEF>()
                .HasKey(pm => new { pm.programCode, pm.member_id });

            //Configuratie voor RunningSessionDetailEF
            modelBuilder.Entity<RunningSessionDetailEF>()
                .HasKey(rs => new { rs.runningsession_id, rs.seq_nr });

            modelBuilder.Entity<RunningSessionDetailEF>()
                .HasKey(rs => new { rs.runningsession_id, rs.seq_nr });

            modelBuilder.Entity<ReservationEF>()
                .HasKey(r => new { r.reservation_id, r.time_slot_id, r.equipment_id });
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);

        }
    }
}