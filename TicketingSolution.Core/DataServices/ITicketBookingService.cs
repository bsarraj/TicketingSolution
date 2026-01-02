using System;
using System.Collections.Generic;
using System.Text;
using TicketingSolution.Domain.Domain;

namespace TicketingSolution.Core.DataServices
{
    public interface ITicketBookingService
    {
        void Save(TicketBooking ticketBooking);

        IEnumerable<Ticket> GetAvailableTickets(DateTime date);

    }
}
