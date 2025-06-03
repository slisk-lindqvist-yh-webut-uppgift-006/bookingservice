namespace Application.Models;

public class Booking
{
    public string Id { get; set; } = null!;
    public string EventId { get; set; } = null!;
    public DateTime BookingDate { get; set; }
    public int TicketQuantity { get; set; }
    public BookingOwner Owner { get; set; } = null!;
}