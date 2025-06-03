using Application.Models;

namespace Application.Interfaces;

public interface IBookingService
{
    Task<ServiceResult> CreateBookingAsync(CreateBookingRequest request);
    Task<ServiceResult<IEnumerable<Booking>>> GetAllBookingsAsync();
}