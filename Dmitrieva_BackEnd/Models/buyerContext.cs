using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Dmitrieva_BackEnd.Models
{
    public class buyerContext:DbContext
    {
        public buyerContext(DbContextOptions<buyerContext> options)
            : base(options)
        {
        }

        public DbSet<buyer> buyers { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<buyer>()
                .OwnsMany(property => property.pumps);
        }

        public IEnumerable<buyer> getSolvency()
        {
            return
                from f in buyers
                where f.budget >= 10000
                select f;

        }
    }
}
