using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AutoZone.Domain.Models;
using AutoZone.Data.Repositories;

namespace AutoZone.Service.Services;

/// <summary>
/// Service for user-related business logic operations.
/// Provides user management functionality including authentication and registration.
/// </summary>
public interface IUserService
{

    /// <summary>
    /// Retrieves a user by their unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the user to retrieve.</param>
    /// <returns>The user with the specified ID, or null if not found.</returns>
    Task<User?> GetUserByIdAsync(Guid id);

    /// <summary>
    /// Retrieves a user by their username.
    /// </summary>
    /// <param name="username">The username of the user to retrieve.</param>
    /// <returns>The user with the specified username, or null if not found.</returns>
    Task<User?> GetUserByUsernameAsync(string username);

    /// <summary>
    /// Retrieves all users in the system.
    /// </summary>
    /// <returns>A collection of all users in the system.</returns>
    Task<IEnumerable<User>> GetAllUsersAsync();

    /// <summary>
    /// Registers a new user in the system with hashed password.
    /// </summary>
    /// <param name="username">The username for the new user account.</param>
    /// <param name="email">The email address for the new user account.</param>
    /// <param name="password">The password for the new user account (will be hashed).</param>
    /// <param name="role">The role assigned to the new user account.</param>
    /// <returns>A task representing the asynchronous registration operation.</returns>
    Task RegisterAsync(string username, string email, string password, Role role);
}
