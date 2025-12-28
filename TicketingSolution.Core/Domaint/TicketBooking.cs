using TicketingSolution.Core.Model;

namespace TicketingSolution.Core.Domaint
{
    public class TicketBooking : ServiceBookingBase
    {
        public static object Id { get; set; }
        public int TicketID { get; set; }
    }
}