using Shouldly;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TicketingSolution.Core.Model;
using TicketingSolution.Core.Handler;

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

        [Fact]
        public void Should_Throw_Exception_For_Null_Request()
        {
            var Handler = new TicketBookingRequestHandler();
            var exception = Should.Throw<ArgumentNullException>(() => Handler.BookService(null));
            exception.ParamName.ShouldBe("bookingRequest");
            //Assert.Throws<ArgumentNullException>(() => Handler.BookService(null));
        }
    }
}
