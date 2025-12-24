


namespace TicketingSolution.Core.Test
{
    internal class TicketBookingRequestHandler
    {
        public TicketBookingRequestHandler()
        {
        }

        internal ServiceBookingResult BookService(TicketBookingRequest bookingRequest)
        {
            
            return new ServiceBookingResult() 
            {
                Name = bookingRequest.Name,
                Family = bookingRequest.Family,
                Email = bookingRequest.Email

            };
        }
    }
}