using Application.Factories;
using Application.Interfaces;
using Application.Models;
using Persistence.Entities;
using Persistence.Repositories;

namespace Application.Services;

public class BookingService(IBookingRepository bookingRepository) : IBookingService
{
    private readonly IBookingRepository _bookingRepository = bookingRepository;

    public async Task<ServiceResult> CreateBookingAsync(CreateBookingRequest request)
    {
        try
        {
            var bookingEntity = new BookingEntity
            {
                EventId = request.EventId,
                BookingDate = DateTime.Now,
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

            var result = await _bookingRepository.AddAsync(bookingEntity);

            return result.Succeeded
                ? ServiceResultFactory.Success(result.Result, 201, "Booking created successfully.")
                : ServiceResultFactory.Error(500, $"Failed to create booking: {result.Error}");
        }
        catch (Exception ex)
        {
            return ServiceResultFactory.Error(500, $"An unexpected error occurred: {ex.Message}");
        }
    }
}