using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using TicketingSolution.Persistence;
using TicketingSolution.Persistence.Repositories;
using TicketingSolution.Domain.Domain;

namespace TicketingSolution.Persistence.Test
{
    public class TicketBookingServiceTest
    {
        [Fact]
        public void Should_Return_Available_Services()
        {
            var date = new DateTime(2026, 1, 1);

            var dbOptions = new DbContextOptionsBuilder<TicketingSolutionDbContext>()
                .UseInMemoryDatabase(databaseName: "AvailableTicketTest")
                .Options;

            using var context = new TicketingSolutionDbContext(dbOptions);
            context.Add(new Ticket { Id = 1, Name = "Ticket 1" });
            context.Add(new Ticket { Id = 2, Name = "Ticket 2" });
            context.Add(new Ticket { Id = 3, Name = "Ticket 3" });

            context.Add(new TicketBooking { TicketID = 1, Name = "T1", Family = "T1", Email = "T1@t1.com", Date = date });

            context.Add(new TicketBooking { TicketID = 2, Name = "T2", Family = "T2", Email = "T2@t2.com", Date = date.AddDays(-1)});

            context.SaveChanges();

            var ticketBookingService = new TicketBookingService(context);

            var availableServices = ticketBookingService.GetAvailableTickets(date);

            Assert.Equal(2, availableServices.Count());
            Assert.Contains(availableServices, t => t.Id == 2);
            Assert.Contains(availableServices, t => t.Id == 3);
            Assert.DoesNotContain(availableServices, t => t.Id == 1);


        }
    }
}
