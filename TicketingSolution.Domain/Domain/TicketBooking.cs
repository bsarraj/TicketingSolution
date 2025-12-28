using TicketingSolution.Domain.BaseModels;

namespace TicketingSolution.Domain.Domain
{
    public class TicketBooking : ServiceBookingBase
    {
        public static object Id { get; set; }
        public int TicketID { get; set; }
    }
}