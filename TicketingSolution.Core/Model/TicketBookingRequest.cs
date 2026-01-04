using TicketingSolution.Core.Enums;
using TicketingSolution.Domain.BaseModels;

namespace TicketingSolution.Core.Model
{
    public class TicketBookingRequest : ServiceBookingBase
    {
        public BoockingResultFlag Flag { get; set; }
    }
}