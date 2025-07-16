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
public class UserService(IUserRepository repo) : IUserService
{
    private readonly IUserRepository _repo = repo;

    /// <inheritdoc/>
    public Task<User?> GetUserByIdAsync(Guid id) => _repo.GetByIdAsync(id);

    /// <inheritdoc/>
    public Task<User?> GetUserByUsernameAsync(string username) => _repo.GetByUsernameAsync(username);

    /// <inheritdoc/>
    public Task<IEnumerable<User>> GetAllUsersAsync() => _repo.GetAllAsync();

    /// <inheritdoc/>
    public async Task RegisterAsync(string username, string email, string password, Role role)
    {
        var hash = HashString(password);
        var user = new User
        {
            Id = Guid.NewGuid(),
            Username = username,
            Email = email,
            PasswordHash = hash,
            Role = role
        };
        await _repo.AddAsync(user);
    }
        
    /// <summary>
    /// Hashes a string using SHA256 algorithm.
    /// </summary>
    /// <param name="input">The string to hash.</param>
    /// <returns>The base64 encoded hash of the input string.</returns>
    private static string HashString(string input) => Convert.ToBase64String(SHA256.HashData(Encoding.UTF8.GetBytes(input)));
}
