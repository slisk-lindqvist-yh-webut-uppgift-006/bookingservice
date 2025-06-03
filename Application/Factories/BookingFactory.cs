using Application.Models;
using Persistence.Entities;

namespace Application.Factories;

public class BookingFactory
{
    public static BookingEntity ToEntity(CreateBookingRequest request) =>
        new()
        {
            EventId = request.EventId,
            BookingDate = DateTime.UtcNow,
            TicketQuantity = request.TicketQuantity,
            BookingOwner = new BookingOwnerEntity
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Address = new BookingAddressEntity
                {
                    StreetName = request.StreetName,
                    PostalCode = request.PostalCode,
                    City = request.City,
                    Country = request.Country
                }
            }
        };
    
    public static Booking ToModel(BookingEntity entity) => new Booking
    {
        Id = entity.Id,
        EventId = entity.EventId,
        BookingDate = entity.BookingDate,
        TicketQuantity = entity.TicketQuantity,
        Owner = new BookingOwner
        {
            FirstName = entity.BookingOwner!.FirstName,
            LastName = entity.BookingOwner.LastName,
            Email = entity.BookingOwner.Email,
            Address = new BookingAddress
            {
                StreetName = entity.BookingOwner.Address!.StreetName,
                PostalCode = entity.BookingOwner.Address.PostalCode,
                City = entity.BookingOwner.Address.City,
                Country = entity.BookingOwner.Address.Country
            }
        }
    };
}