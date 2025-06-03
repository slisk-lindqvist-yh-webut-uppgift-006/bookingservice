namespace Application.Models;

public class BookingOwner
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public BookingAddress Address { get; set; } = null!;
}