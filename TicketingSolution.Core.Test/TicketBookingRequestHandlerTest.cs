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
using TicketingSolution.Core.Enums;
using TicketingSolution.Domain.Domain;

namespace TicketingSolution.Core.Test
{
    public class Ticket_Booking_Request_Handler_Test
    {
        private TicketBookingRequestHandler _handler;
        private readonly TicketBookingRequest _request;
        private readonly List<Ticket> _availlableTickets;
        private readonly Mock<ITicketBookingService> _ticketBookingServiceMock;

        public Ticket_Booking_Request_Handler_Test()
        {

            _request = new TicketBookingRequest
            {
                Name = "Test",
                Family = "Family",
                Email = "Email",
                Date = DateTime.Now
            };
            _availlableTickets = new List<Ticket>() { new Ticket() { Id = 1 } };
            _ticketBookingServiceMock = new Mock<ITicketBookingService>();
            _ticketBookingServiceMock.Setup(q => q.GetAvailabelTickets(_request.Date))
                .Returns(_availlableTickets);
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
            saveBooking.TicketID.ShouldBe(_availlableTickets.First().Id);

        }

        [Fact]
        public void Should_Return_Ticket_Booking_Response_With_Request_Values()
        {
            _availlableTickets.Clear();
            _handler.BookService(_request);
            _ticketBookingServiceMock.Verify(x => x.Save(It.IsAny<TicketBooking>()), Times.Never);
        }

        [Theory]
        [InlineData(BoockingResultFlag.Failure, false)]
        [InlineData(BoockingResultFlag.Success, true)]
        public void Should_Return_SuccessOrFailure_Flag_In_Result(BoockingResultFlag boockingSuccessFlag, bool isAvailable)
        {
            if (!isAvailable)
            {
                _availlableTickets.Clear();
            }

            var result = _handler.BookService(_request);
            boockingSuccessFlag.ShouldBe(result.Flag);
        }

        [Theory]
        [InlineData(1,true)]
        [InlineData(null, false)]
        public void Should_Return_TicketBookingId_In_Result(int? ticketBookingId, bool isAvailable)
        {
            if (!isAvailable)
            {
                _availlableTickets.Clear();
            }
            else
            {   
                _ticketBookingServiceMock.Setup(x => x.Save(It.IsAny<TicketBooking>()))
                .Callback<TicketBooking>(booking =>
                {
                    TicketBooking.Id = ticketBookingId.Value;
                });
            }
            var result = _handler.BookService(_request);

            result.TicketBookingId.ShouldBe(ticketBookingId);

        }
    }
}
