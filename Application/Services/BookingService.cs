using Application.Factories;
using Application.Interfaces;
using Application.Models;
using Persistence.Entities;
using Persistence.Repositories;
// using System.Linq;

namespace Application.Services;

public class BookingService(IBookingRepository bookingRepository) : IBookingService
{
    private readonly IBookingRepository _bookingRepository = bookingRepository;

    // public async Task<ServiceResult> CreateBookingAsync(CreateBookingRequest request)
    // {
    //     try
    //     {
    //         var bookingEntity = new BookingEntity
    //         {
    //             EventId = request.EventId,
    //             BookingDate = DateTime.Now,
    //             TicketQuantity = request.TicketQuantity,
    //             BookingOwner = new BookingOwnerEntity
    //             {
    //                 FirstName = request.FirstName,
    //                 LastName = request.LastName,
    //                 Email = request.Email,
    //                 Address = new BookingAddressEntity
    //                 {
    //                     StreetName = request.StreetName,
    //                     PostalCode = request.PostalCode,
    //                     City = request.City,
    //                     Country = request.Country
    //                 }
    //             }
    //         };
    //
    //         var result = await _bookingRepository.AddAsync(bookingEntity);
    //
    //         return result.Succeeded
    //             ? ServiceResultFactory.Success(result.Result, 201, "Booking created successfully.")
    //             : ServiceResultFactory.Error(500, $"Failed to create booking: {result.Error}");
    //     }
    //     catch (Exception ex)
    //     {
    //         return ServiceResultFactory.Error(500, $"An unexpected error occurred: {ex.Message}");
    //     }
    // }
    
    public async Task<ServiceResult> CreateBookingAsync(CreateBookingRequest request)
    {
        try
        {
            if (request == null)
                return ServiceResultFactory.Error(400, "Booking request cannot be null.");

            if (request.TicketQuantity <= 0)
                return ServiceResultFactory.Error(400, "Ticket quantity must be greater than zero.");

            var bookingEntity = BookingFactory.ToEntity(request);

            var result = await _bookingRepository.AddAsync(bookingEntity);

            return result.Succeeded
                ? ServiceResultFactory.Success(result.Result, 201, "Booking created successfully.")
                : ServiceResultFactory.Error(result.StatusCode, $"Failed to create booking: {result.Error}");
        }
        catch (Exception ex)
        {
            // log exception here if a logger is available
            return ServiceResultFactory.Error(500, $"An unexpected error occurred: {ex.Message}");
        }
    }

    public async Task<ServiceResult<IEnumerable<Booking>>> GetAllBookingsAsync()
    {
        try
        {
            var result = await _bookingRepository.GetAllAsync();

            if (!result.Succeeded || result.Result == null)
                return ServiceResultFactory.Error<IEnumerable<Booking>>(result.StatusCode, $"Failed to retrieve bookings: {result.Error}");

            var models = result.Result.Select(BookingFactory.ToModel).ToList();

            return ServiceResultFactory.Success<IEnumerable<Booking>>(models, 200, "Bookings retrieved successfully.");
        }
        catch (Exception ex)
        {
            return ServiceResultFactory.Error<IEnumerable<Booking>>(500, $"An unexpected error occurred: {ex.Message}");
        }
    }

}