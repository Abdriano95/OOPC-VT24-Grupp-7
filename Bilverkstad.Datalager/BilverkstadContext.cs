using Bilverkstad.Entitetlagret;
using Microsoft.Data.SqlClient;
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=sqlutb2-db.hb.se,56077;Database=oopc2407;Trusted_Connection=True;User Id=oopc2407;Password=VNW786;Integrated Security=False;Encrypt=False");
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

            // Configure the Bokning-Mekaniker relationship
            modelBuilder.Entity<Mekaniker>()
                .HasMany(m => m.Bokningar)
                .WithOne(b => b.Mekaniker) 
                .HasForeignKey(b => b.MekanikerId)
                .OnDelete(DeleteBehavior.NoAction);// Prevent cascading delete

            // Configure the Bokning-Reparation relationship
            modelBuilder.Entity<Reparation>()
                .HasOne(r => r.Bokning)
                .WithMany(b => b.Reparation)
                .HasForeignKey(r => r.BokningsId)
                .OnDelete(DeleteBehavior.NoAction); // Prevent cascading delete

        }
    }
}
