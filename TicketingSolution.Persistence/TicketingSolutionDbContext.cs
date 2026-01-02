using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TicketingSolution.Domain.Domain;

namespace TicketingSolution.Persistence
{
    public class TicketingSolutionDbContext : DbContext
    {

        public TicketingSolutionDbContext(DbContextOptions<TicketingSolutionDbContext> options)
            : base(options)
        {
               
        }

        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketBooking> TicketBookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TicketBooking>().HasKey(tb => tb.TicketID);
            modelBuilder.Entity<TicketBooking>()
                .HasOne<Ticket>(tb => tb.Ticket)
                .WithMany(t => t.TicketBookings)
                .HasForeignKey(tb => tb.TicketID);
        }
        
    }
}

