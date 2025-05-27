using System.ComponentModel.DataAnnotations;

namespace Application.Models;

public class CreateBookingRequest
{
    [Required(ErrorMessage = "Event ID is required.")]
    [Display(Name = "Event ID", Prompt = "Enter the event identifier")]
    public string EventId { get; set; } = null!;

    [Required(ErrorMessage = "First name is required.")]
    [MaxLength(100, ErrorMessage = "First name cannot exceed 100 characters.")]
    [Display(Name = "First Name", Prompt = "Enter your first name")]
    public string FirstName { get; set; } = null!;

    [Required(ErrorMessage = "Last name is required.")]
    [MaxLength(100, ErrorMessage = "Last name cannot exceed 100 characters.")]
    [Display(Name = "Last Name", Prompt = "Enter your last name")]
    public string LastName { get; set; } = null!;

    [Required(ErrorMessage = "Email address is required.")]
    [MaxLength(255, ErrorMessage = "Email address cannot exceed 255 characters.")]
    [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]{2,}$", ErrorMessage = "Invalid email address format.")]
    [Display(Name = "Email", Prompt = "Enter your email address")]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "Street name is required.")]
    [MaxLength(200, ErrorMessage = "Street name cannot exceed 200 characters.")]
    [Display(Name = "Street Name", Prompt = "Enter your street name")]
    public string StreetName { get; set; } = null!;

    [Required(ErrorMessage = "Postal code is required.")]
    [MaxLength(20, ErrorMessage = "Postal code cannot exceed 20 characters.")]
    [Display(Name = "Postal Code", Prompt = "Enter your postal code")]
    public string PostalCode { get; set; } = null!;

    [Required(ErrorMessage = "City is required.")]
    [MaxLength(100, ErrorMessage = "City name cannot exceed 100 characters.")]
    [Display(Name = "City", Prompt = "Enter your city")]
    public string City { get; set; } = null!;
    
    [Required(ErrorMessage = "Country is required.")]
    [MaxLength(100, ErrorMessage = "Country name cannot exceed 100 characters.")]
    [Display(Name = "Country", Prompt = "Enter your country")]
    public string Country { get; set; } = null!;

    public int TicketQuantity { get; set; } = 1;
}