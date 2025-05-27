using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Persistence.Entities;

public class BookingEntity
{
    [Key, Column(TypeName = "nvarchar(36)")]
    public string Id { get; set; } = Guid.NewGuid().ToString();

    [Column(TypeName = "nvarchar(36)")]
    public string EventId { get; set; } = null!;

    [Column(TypeName = "int")]
    public int TicketQuantity { get; set; } = 1;

    [Column(TypeName = "datetime2")]
    public DateTime BookingDate { get; set; }

    [ForeignKey(nameof(BookingOwner)), Column(TypeName = "nvarchar(36)")]
    public string? BookingOwnerId { get; set; }
    public BookingOwnerEntity? BookingOwner { get; set; }
}