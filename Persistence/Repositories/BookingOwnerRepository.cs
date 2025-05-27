using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using Persistence.Entities;
using Persistence.Helper;
using Persistence.Interfaces;
using Persistence.Models;

namespace Persistence.Repositories;

public interface IBookingOwnerRepository : IBaseRepository<BookingOwnerEntity, string>
{
}

public class BookingOwnerRepository(DataContext context)
    : BaseRepository<BookingOwnerEntity, string>(context), IBookingOwnerRepository
{
    public override async Task<RepositoryResult<IEnumerable<BookingOwnerEntity>>> GetAllAsync()
    {
        try
        {
            var result = await _dbSet
                .Include(owner => owner.Address)
                .ToListAsync();
            
            return RepositoryResultFactory.Success<IEnumerable<BookingOwnerEntity>>(result);
        }
        catch (Exception ex)
        {
            return RepositoryResultFactory.Error<IEnumerable<BookingOwnerEntity>>(500, ex.Message);
        }
    }

    public override async Task<RepositoryResult<IEnumerable<BookingOwnerEntity>>> GetAllAsync(Expression<Func<BookingOwnerEntity, bool>> predicate)
    {
        try
        {
            var result = await _dbSet
                .Include(owner => owner.Address)
                .Where(predicate).ToListAsync();
            
            return RepositoryResultFactory.Success<IEnumerable<BookingOwnerEntity>>(result);
        }
        catch (Exception ex)
        {
            return RepositoryResultFactory.Error<IEnumerable<BookingOwnerEntity>>(500, ex.Message);
        }
    }

    public override async Task<RepositoryResult<BookingOwnerEntity?>> GetAsync(string id)
    {
        try
        {
            var result = await _dbSet
                .Include(owner => owner.Address)
                .FirstOrDefaultAsync(x => x.Id == id);
            
            if (result == null)
                return RepositoryResultFactory.Error<BookingOwnerEntity?>(404, "Entity not found.");
                
            return RepositoryResultFactory.Success(result, 200, "Entity retrieved successfully.")!;
        }
        catch (Exception ex)
        {
            return RepositoryResultFactory.Error<BookingOwnerEntity?>(500, ex.Message);
        }
    }

    public override async Task<RepositoryResult<BookingOwnerEntity?>> GetAsync(Expression<Func<BookingOwnerEntity, bool>> predicate)
    {
        try
        {
            var result = await _dbSet
                .Include(owner => owner.Address)
                .FirstOrDefaultAsync(predicate);
            
            if (result == null)
                return RepositoryResultFactory.Error<BookingOwnerEntity?>(404, "Entity not found.");

            return RepositoryResultFactory.Success<BookingOwnerEntity?>(result, 200, "Entity retrieved successfully.");
        }
        catch (Exception ex)
        {
            return RepositoryResultFactory.Error<BookingOwnerEntity?>(500, ex.Message);
        }
    }
}

