using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adress_import.Data
{
    internal class Context : DbContext
    {
        public DbSet<Ortschaften> Ortschaften { get; set; }
        public DbSet<Firmen> Firmen { get; set; }
        public DbSet<Adressen> Adressen { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=Localhost;Database=adress_import;Trusted_Connection=true;TrustedCertificate=true");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ortschaften>().ToTable("Ortschaften");
            modelBuilder.Entity<Ortschaften>().HasKey(o => o.OID);

            modelBuilder.Entity<Firmen>().ToTable("Firmen");
            modelBuilder.Entity<Firmen>().HasKey(f => f.FID);

            modelBuilder.Entity<Adressen>().ToTable("Adressen");
            modelBuilder.Entity<Adressen>().HasKey(a => a.AID);

            modelBuilder.Entity<Adressen>()
                .HasOne(a => a.Firma) // Navigation property in Adressen for Firmen
                .WithMany(f => f.Adressen) // Navigation property in Firmen for Adressen
                .HasForeignKey(a => a.FK_FID) // Foreign key property in Adressen
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Adressen>()
                .HasOne(a => a.Firma) // Navigation property in Adressen for Ortschaften
                .WithMany(o => o.Adressen) // Navigation property in Ortschaften for Adressen
                .HasForeignKey(a => a.FK_OID) // Foreign key property in Adressen
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}
