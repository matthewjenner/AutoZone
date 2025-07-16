using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoZone.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoZone.Data.Repositories;

/// <summary>
/// Repository implementation for user data access operations using Entity Framework Core.
/// Provides CRUD operations for user entities with related data loading.
/// </summary>
public class UserRepository(AutoZoneDbContext context) : IUserRepository
{
    /// <inheritdoc/>
    public async Task<User?> GetByIdAsync(Guid id)
        => await context.Users.Include(x => x.Vehicles).Include(x => x.Transactions).FirstOrDefaultAsync(x => x.Id == id);

    /// <inheritdoc/>
    public async Task<User?> GetByUsernameAsync(string username)
        => await context.Users.FirstOrDefaultAsync(x => x.Username == username);

    /// <inheritdoc/>
    public async Task<IEnumerable<User>> GetAllAsync()
        => await context.Users.ToListAsync();

    /// <inheritdoc/>
    public async Task AddAsync(User user)
    {
        await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
    }

    /// <inheritdoc/>
    public async Task UpdateAsync(User user)
    {
        context.Users.Update(user);
        await context.SaveChangesAsync();
    }

    /// <inheritdoc/>
    public async Task DeleteAsync(Guid id)
    {
        User? user = await GetByIdAsync(id);
        if (user != null)
        {
            context.Users.Remove(user);
            await context.SaveChangesAsync();
        }
    }
}
