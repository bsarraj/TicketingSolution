using System;
using System.Collections.Generic;
using System.Text;
using TicketingSolution.Core.DataServices;
using TicketingSolution.Domain.Domain;

namespace TicketingSolution.Persistence.Repositories
{
    public class TicketBookingService : ITicketBookingService
    {
        public IEnumerable<Ticket> GetAvailabelTickets(DateTime date)
        {
            throw new NotImplementedException();
        }

        public void Save(TicketBooking ticketBooking)
        {
            throw new NotImplementedException();
        }
    }
}
