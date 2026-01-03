using Microsoft.EntityFrameworkCore;
using TicketingSolution.Domain.Domain;
using TicketingSolution.Persistence;
using TicketingSolution.Persistence.Repositories;

namespace TicketingSolution.Persistence.Test
{
    public class TicketBookingServiceTest
    {
        [Fact]
        public void Should_Save_Ticket_Booking()
        {
            // Arrange
            var dbOptions = new DbContextOptionsBuilder<TicketingSolutionDbContext>()
                .UseInMemoryDatabase(databaseName: "ShouldSaveTest", b => b.EnableNullChecks(false))
                .Options;
            var ticketBooking = new TicketBooking() { TicketID = 1, Date = new DateTime(2022, 06, 01)};

            // Act
            using var context = new TicketingSolutionDbContext(dbOptions);
            var ticketBookingService = new TicketBookingService(context);
            ticketBookingService.Save(ticketBooking);

            // Assert

            Assert.NotNull(ticketBooking);
            Assert.Equal(1, ticketBooking.TicketID);
            Assert.Equal(new DateTime(2022, 06, 01), ticketBooking.Date);
        }

        [Fact]
        public void Should_Return_Available_Services()
        {
            var date = new DateTime(2026, 1, 1);

            var dbOptions = new DbContextOptionsBuilder<TicketingSolutionDbContext>()
                .UseInMemoryDatabase(databaseName: "AvailableTicketTest", b => b.EnableNullChecks(false))
                .Options;

            using var context = new TicketingSolutionDbContext(dbOptions);
            context.Add(new Ticket { Id = 1, Name = "Ticket 1" });
            context.Add(new Ticket { Id = 2, Name = "Ticket 2" });
            context.Add(new Ticket { Id = 3, Name = "Ticket 3" });

            context.Add(new TicketBooking { TicketID = 1, Date = date });
            context.Add(new TicketBooking { TicketID = 2, Date = date.AddDays(-1)});

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
