using System;
using System.Collections.Generic;
using System.Text;
using TicketingSolution.Core.Domaint;

namespace TicketingSolution.Core.DataServices
{
    public interface ITicketBookingService
    {
        void Save(TicketBooking ticketBooking);

        IEnumerable<Ticket> GetAvailabelTickets(DateTime date);

    }
}
