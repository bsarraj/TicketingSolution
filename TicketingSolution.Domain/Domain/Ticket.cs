using System.ComponentModel.DataAnnotations;

namespace TicketingSolution.Domain.Domain
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}