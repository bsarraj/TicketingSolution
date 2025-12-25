using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;
using Shouldly;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TicketingSolution.Core.DataServices;
using TicketingSolution.Core.Handler;
using TicketingSolution.Core.Model;
using Moq;
using TicketingSolution.Core.Domaint;

namespace TicketingSolution.Core.Test
{
    public class Ticket_Booking_Request_Handler_Test
    {
        private TicketBookingRequestHandler _handler;
        private readonly TicketBookingRequest _request;
        private readonly Mock<ITicketBookingService> _ticketBookingServiceMock;

        public Ticket_Booking_Request_Handler_Test()
        {

            _request = new TicketBookingRequest
            {
                Name = "Test",
                Family = "Family",
                Email = "Email"
            };
            _ticketBookingServiceMock = new Mock<ITicketBookingService>();
            _handler = new TicketBookingRequestHandler(_ticketBookingServiceMock.Object);

        }
        [Fact]
        public void Shuld_Return_Ticket_Booking_Response_With_Request_Values()
        {
            ServiceBookingResult result = _handler.BookService(_request);


            result.ShouldNotBeNull();
            result.Name.ShouldBe(_request.Name);
            result.Family.ShouldBe(_request.Family);
            result.Email.ShouldBe(_request.Email);

        }

        [Fact]
        public void Should_Throw_Exception_For_Null_Request()
        {
            var exception = Should.Throw<ArgumentNullException>(() => _handler.BookService(null));
            exception.ParamName.ShouldBe("bookingRequest");
            //Assert.Throws<ArgumentNullException>(() => Handler.BookService(null));
        }

        [Fact]
        public void Should_Save_Ticket_Booking_Request()
        {
            TicketBooking saveBooking = null;
            _ticketBookingServiceMock.Setup(x => x.Save(It.IsAny<TicketBooking>()))
                .Callback<TicketBooking>(booking =>
                {
                    saveBooking = booking;
                });
            _handler.BookService(_request);

            _ticketBookingServiceMock.Verify(x => x.Save(It.IsAny<TicketBooking>()), Times.Once);
            saveBooking.ShouldNotBeNull();
            saveBooking.Name.ShouldBe(_request.Name);
            saveBooking.Family.ShouldBe(_request.Family);
            saveBooking.Email.ShouldBe(_request.Email);

        }
    }
}
