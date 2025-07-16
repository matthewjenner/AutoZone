using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoZone.Domain.Models;

namespace AutoZone.Data.Repositories;

/// <summary>
/// Repository interface for user data access operations.
/// Provides CRUD operations for user entities with related data loading capabilities.
/// </summary>
public interface IUserRepository
{
    /// <summary>
    /// Retrieves a specific user by their unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the user to retrieve.</param>
    /// <returns>The user with the specified ID, or null if not found.</returns>
    Task<User?> GetByIdAsync(Guid id);

    /// <summary>
    /// Retrieves a user by their username.
    /// </summary>
    /// <param name="username">The username of the user to retrieve.</param>
    /// <returns>The user with the specified username, or null if not found.</returns>
    Task<User?> GetByUsernameAsync(string username);

    /// <summary>
    /// Retrieves all users from the database.
    /// </summary>
    /// <returns>A collection of all users in the database.</returns>
    Task<IEnumerable<User>> GetAllAsync();

    /// <summary>
    /// Creates a new user in the database.
    /// </summary>
    /// <param name="user">The user entity to create.</param>
    /// <returns>A task representing the asynchronous creation operation.</returns>
    Task AddAsync(User user);

    /// <summary>
    /// Updates an existing user in the database.
    /// </summary>
    /// <param name="user">The user entity with updated properties.</param>
    /// <returns>A task representing the asynchronous update operation.</returns>
    Task UpdateAsync(User user);

    /// <summary>
    /// Deletes a user from the database by their unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the user to delete.</param>
    /// <returns>A task representing the asynchronous deletion operation.</returns>
    Task DeleteAsync(Guid id);
}
