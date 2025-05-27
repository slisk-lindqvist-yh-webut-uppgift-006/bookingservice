using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using Persistence.Entities;
using Persistence.Helper;
using Persistence.Interfaces;
using Persistence.Models;

namespace Persistence.Repositories;

public interface IBookingRepository : IBaseRepository<BookingEntity, string>
{
}

public class BookingRepository(DataContext context)
    : BaseRepository<BookingEntity, string>(context), IBookingRepository
{
    public override async Task<RepositoryResult<IEnumerable<BookingEntity>>> GetAllAsync()
    {
        try
        {
            var result = await _dbSet
                .Include(x => x.BookingOwner)
                .ThenInclude(owner => owner!.Address)
                .ToListAsync();
            
            return RepositoryResultFactory.Success<IEnumerable<BookingEntity>>(result);
        }
        catch (Exception ex)
        {
            return RepositoryResultFactory.Error<IEnumerable<BookingEntity>>(500, ex.Message);
        }
    }

    public override async Task<RepositoryResult<IEnumerable<BookingEntity>>> GetAllAsync(Expression<Func<BookingEntity, bool>> predicate)
    {
        try
        {
            var result = await _dbSet
                .Include(x => x.BookingOwner)
                .ThenInclude(owner => owner!.Address)
                .Where(predicate).ToListAsync();
            
            return RepositoryResultFactory.Success<IEnumerable<BookingEntity>>(result);
        }
        catch (Exception ex)
        {
            return RepositoryResultFactory.Error<IEnumerable<BookingEntity>>(500, ex.Message);
        }
    }

    public override async Task<RepositoryResult<BookingEntity?>> GetAsync(string id)
    {
        try
        {
            var result = await _dbSet
                .Include(x => x.BookingOwner)
                .ThenInclude(owner => owner!.Address)
                .FirstOrDefaultAsync(x => x.Id == id);
            
            if (result == null)
                return RepositoryResultFactory.Error<BookingEntity?>(404, "Entity not found.");
                
            return RepositoryResultFactory.Success(result, 200, "Entity retrieved successfully.")!;
        }
        catch (Exception ex)
        {
            return RepositoryResultFactory.Error<BookingEntity?>(500, ex.Message);
        }
    }

    public override async Task<RepositoryResult<BookingEntity?>> GetAsync(Expression<Func<BookingEntity, bool>> predicate)
    {
        try
        {
            var result = await _dbSet
                .Include(x => x.BookingOwner)
                .ThenInclude(owner => owner!.Address)
                .FirstOrDefaultAsync(predicate);
            
            if (result == null)
                return RepositoryResultFactory.Error<BookingEntity?>(404, "Entity not found.");

            return RepositoryResultFactory.Success<BookingEntity?>(result, 200, "Entity retrieved successfully.");
        }
        catch (Exception ex)
        {
            return RepositoryResultFactory.Error<BookingEntity?>(500, ex.Message);
        }
    }
}