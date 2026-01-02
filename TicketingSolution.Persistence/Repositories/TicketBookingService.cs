using System;
using System.Collections.Generic;
using System.Text;
using TicketingSolution.Core.DataServices;
using TicketingSolution.Domain.Domain;

namespace TicketingSolution.Persistence.Repositories
{
    public class TicketBookingService : ITicketBookingService
    {
        private readonly TicketingSolutionDbContext _context;

        public TicketBookingService(TicketingSolutionDbContext context)
        {
            this._context = context;
        }

        

        public IEnumerable<Ticket> GetAvailableTickets(DateTime date)
        {
            return _context.Tickets
                .Where(t => !t.TicketBookings.Any(b => b.Date == date))
                .ToList();
        }

        public void Save(TicketBooking ticketBooking)
        {
            throw new NotImplementedException();
        }
    }
}
