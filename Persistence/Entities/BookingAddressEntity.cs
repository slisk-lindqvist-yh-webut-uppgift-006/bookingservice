using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Persistence.Entities;

public class BookingAddressEntity
{
    [Key, Column(TypeName = "nvarchar(36)")]
    public string Id { get; set; } = Guid.NewGuid().ToString();

    [Column(TypeName = "nvarchar(200)")]
    public string StreetName { get; set; } = null!;

    [Column(TypeName = "nvarchar(20)")]
    public string PostalCode { get; set; } = null!;

    [Column(TypeName = "nvarchar(100)")]
    public string City { get; set; } = null!;

    [Column(TypeName = "nvarchar(100)")]
    public string Country { get; set; } = null!;
}