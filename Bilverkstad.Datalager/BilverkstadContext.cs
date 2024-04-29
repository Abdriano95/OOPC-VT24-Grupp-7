using Bilverkstad.Entitetlagret;
using Microsoft.EntityFrameworkCore;

namespace Bilverkstad.Datalager
{
    public class BilverkstadContext : DbContext
    {
        public DbSet<Kund> Kund { get; set; }
        public DbSet<Anställd> Anställd { get; set; }
        public DbSet<Bokning> Bokning { get; set; }
        public DbSet<Fordon> Fordon { get; set; }
        public DbSet<Reparation> Reparation { get; set; }
        public DbSet<Reservdel> Reservdel { get; set; }
        public DbSet<Receptionist> Receptionist { get; set; }
        public DbSet<Mekaniker> Mekaniker { get; set; }
        public DbSet<ReparationReservdel> ReparationReservdel { get; set; } 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Bilverkstad;Integrated Security=True");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the Bokning-Kund relationship
            modelBuilder.Entity<Bokning>()
                .HasOne(b => b.Kund)
                .WithMany()
                .HasForeignKey(b => b.KundId)
                .OnDelete(DeleteBehavior.NoAction); // Prevent cascading delete

            // Configure the Bokning-Fordon relationship
            modelBuilder.Entity<Bokning>()
                .HasOne(b => b.Fordon)
                .WithMany()
                .HasForeignKey(b => b.FordonRegNr)
                .OnDelete(DeleteBehavior.NoAction); // Prevent cascading delete

            // Configure the Reparation-Reservdel relationship
            modelBuilder.Entity<ReparationReservdel>()
                .HasKey(rr => new { rr.ReparationId, rr.ReservdelId }); 

            //modelBuilder.Entity<Reservdel>()
            //    .Property(r => r.Artikelnummer)
            //    .ValueGeneratedOnAdd();
            // Configure the Repartaion-Reservdel relationship
            //modelBuilder.Entity<Reparation>()
            //    .HasOne(r => r.Reservdelar)
            //    .WithOne()
            //    .HasForeignKey(r => r.Artikelnummer)
            //    .IsRequired(false); // Prevent cascading delete


        }


    }
}
