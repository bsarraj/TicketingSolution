using TicketingSolution.Core.Enums;
using TicketingSolution.Domain.BaseModels;

namespace TicketingSolution.Core.Model
{
    public class ServiceBookingResult : ServiceBookingBase
    {
        public BoockingResultFlag Flag { get; set; }

        public int? TicketBookingId { get; set; }

    }
}