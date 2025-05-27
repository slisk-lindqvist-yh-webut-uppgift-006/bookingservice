using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Persistence.Entities;

public class BookingOwnerEntity
{
    [Key, Column(TypeName = "nvarchar(36)")]
    public string Id { get; set; } = Guid.NewGuid().ToString();

    [Column(TypeName = "nvarchar(100)")]
    public string FirstName { get; set; } = null!;

    [Column(TypeName = "nvarchar(100)")]
    public string LastName { get; set; } = null!;

    [Column(TypeName = "nvarchar(255)")]
    public string Email { get; set; } = null!;

    [ForeignKey(nameof(Address)), Column(TypeName = "nvarchar(36)")]
    public string? BookingAddressId { get; set; }
    public BookingAddressEntity? Address { get; set; }
}