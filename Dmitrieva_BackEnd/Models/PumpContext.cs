using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Dmitrieva_BackEnd.Models
{
    public class PumpContext : DbContext
    {
        public PumpContext(DbContextOptions<PumpContext> options)
            : base(options)
        {
        }

        public DbSet<Pump> Pumps { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pump>()
                .OwnsMany(property => property.ppumps);
        }
        public IEnumerable<Pump> getQuality()
        {
            return
                from p in Pumps
                where (p.barrel >= 50)
                select p;
        }
    }
}
