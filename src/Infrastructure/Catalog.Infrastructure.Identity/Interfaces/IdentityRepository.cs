using Catalog.Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace Catalog.Infrastructure.Identity.Interfaces
{
    public interface IIdentityRepository
    {
        Task<IdentityResult> CreateUserAsync(string name, string email);
        Task<IdentityResult> CreateUserAsync(string name, string email, string password, string role);
        Task<string> GenerateEmailConfirmationTokenAsync(string email);
        Task<bool> ConfirmEmailAsync(string email, string token);
        Task<User> LoginAsync(string email, string password);
        Task<IEnumerable<string>> GetRolesAsync(User user);
        Task<User> ForgotPasswordAsync(string email);
        Task<string> GeneratePasswordResetTokenAsync(string email);
        Task<string> GeneratePasswordResetTokenAsync(User user);
        Task<IdentityResult> ResetPasswordAsync(string email, string token, string password);
        Task<bool> ChangePasswordAsync(string email, string currentPassword, string newPassword);
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User> FindUserByEmailAsync(string email);
        Task UpdateUserAsync(User user);
        Task<User> FindUserByIdAsync(Guid idUser);
    }
}
