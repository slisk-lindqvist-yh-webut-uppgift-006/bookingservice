using Persistence.Contexts;
using Persistence.Entities;
using Persistence.Interfaces;

namespace Persistence.Repositories;

public interface IBookingAddressRepository : IBaseRepository<BookingAddressEntity, string>
{
}

public class BookingAddressRepository(DataContext context)
    : BaseRepository<BookingAddressEntity, string>(context), IBookingAddressRepository
{
   
}

