using TicketingSolution.Core.DataServices;
using TicketingSolution.Core.Domaint;
using TicketingSolution.Core.Model;

namespace TicketingSolution.Core.Handler
{
    public class TicketBookingRequestHandler
    {
        private readonly ITicketBookingService _ticketBookingService;

        public TicketBookingRequestHandler(ITicketBookingService ticketBookingService)
        {
            this._ticketBookingService = ticketBookingService;
        }

        public ServiceBookingResult BookService(TicketBookingRequest bookingRequest)
        {
            if (bookingRequest is null)
            {
                throw new ArgumentNullException(nameof(bookingRequest));
            }
            var availabeTickets = _ticketBookingService.GetAvailabelTickets(bookingRequest.Date);
            if (availabeTickets.Any())
            {
                var Ticket = availabeTickets.First();
                var TicketBooking = CreateTicketBookingObject<TicketBooking>(bookingRequest);
                TicketBooking.TicketID = Ticket.Id;
                _ticketBookingService.Save(TicketBooking);
            }

            return CreateTicketBookingObject<ServiceBookingResult>(bookingRequest);
        }

        public static TTicketBooking CreateTicketBookingObject<TTicketBooking>(TicketBookingRequest bookingRequest) where TTicketBooking : ServiceBookingBase, new()
        {
            return new TTicketBooking()
            {
                Name = bookingRequest.Name,
                Family = bookingRequest.Family,
                Email = bookingRequest.Email
            };
        }
    }
}