using Application.Models;

namespace Application.Interfaces;

public interface IBookingService
{
    Task<ServiceResult> CreateBookingAsync(CreateBookingRequest request);
}