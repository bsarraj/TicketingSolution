using Shouldly;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TicketingSolution.Core.Test
{
    public class Ticket_Booking_Request_Handler_Test
    {
        [Fact]
        public void Shuld_Return_Ticket_Booking_Response_With_Request_Values()
        {

            var BookingRequest = new TicketBookingRequest
            {
                Name = "Test",
                Family = "Family",
                Email = "Email"
            };

            var Handler = new TicketBookingRequestHandler();

            ServiceBookingResult result = Handler.BookService(BookingRequest);


            result.ShouldNotBeNull();
            result.Name.ShouldBe(BookingRequest.Name);
            result.Family.ShouldBe(BookingRequest.Family);
            result.Email.ShouldBe(BookingRequest.Email);

        }
    }
}
