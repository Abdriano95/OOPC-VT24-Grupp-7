using Bilverkstad.Entitetlagret;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilverkstad.Datalager
{
    public class BilverkstadContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Bilverkstad;Integrated Security=True");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Kund> Kund { get; set; }

    }
}
