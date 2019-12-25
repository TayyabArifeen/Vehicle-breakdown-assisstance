using Glimpse.AspNet.Tab;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreakDown_Assistance.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options):base(options)
        {

        }
        public virtual DbSet <Mechanics>Mechanics { get; set; }
        public virtual DbSet<Request> Requests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Request>()
                .HasOne(c => c.mehanics)
                .WithMany(r => r.requests)
                .HasForeignKey(c => c.mechanic_ID)
                .HasPrincipalKey(t => t.id);

        }

    }
}
