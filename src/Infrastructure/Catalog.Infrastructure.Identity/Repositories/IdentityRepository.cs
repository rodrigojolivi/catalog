using Catalog.Infrastructure.Identity.Contexts;
using Catalog.Infrastructure.Identity.Interfaces;
using Catalog.Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Infrastructure.Identity.Repositories
{
    public class IdentityRepository : IIdentityRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IdentityContext _context;

        public IdentityRepository(UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager, SignInManager<User> signInManager, 
            IdentityContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _context = context; 
        }

        public async Task<IdentityResult> CreateUserAsync(string name, string email)
        {
            var user = new User
            {
                Name = name,
                Email = email,
                UserName = email,
                EmailConfirmed = true
            };

            user.SetCreatedDate();

            var identityResult = await _userManager.CreateAsync(user);

            return identityResult;
        }

        public async Task<IdentityResult> CreateUserAsync(string name, string email, string password, string role)
        {
            var user = new User
            {
                Name = name,
                Email = email,
                UserName = email
            };

            user.SetCreatedDate();

            var identityResult = await _userManager.CreateAsync(user, password);

            var existingRole = await _roleManager.FindByNameAsync(role);

            _context.UserRoles.Add(new IdentityUserRole<string>
            {
                UserId = user.Id,
                RoleId = existingRole.Id
            });

            await _context.SaveChangesAsync();

            return identityResult;
        }

        public async Task<string> GenerateEmailConfirmationTokenAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null) return null;

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

            return token;
        }

        public async Task<bool> ConfirmEmailAsync(string email, string token)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null) return false;

            user.SetUpdatedDate();

            var identityResult = await _userManager.ConfirmEmailAsync(user, token);

            var result = identityResult.Succeeded;

            return result;
        }

        public async Task<User> LoginAsync(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null) return null;

            var signResult = await _signInManager.PasswordSignInAsync(
                user, password, isPersistent: false, lockoutOnFailure: false);

            if (!signResult.Succeeded) return null;

            return user;
        }
        public async Task<IEnumerable<string>> GetRolesAsync(User user)
        {
            return await _userManager.GetRolesAsync(user);
        }

        public async Task<User> ForgotPasswordAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null) return null;

            return user;
        }

        public async Task<string> GeneratePasswordResetTokenAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null) return null;

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            return token;
        }

        public async Task<string> GeneratePasswordResetTokenAsync(User user)
        {
            return await _userManager.GeneratePasswordResetTokenAsync(user);
        }

        public async Task<IdentityResult> ResetPasswordAsync(string email, string token, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null) return new IdentityResult();

            user.SetUpdatedDate();

            token = token.Replace(" ", "+");

            var identityResult = await _userManager.ResetPasswordAsync(user, token, password);

            return identityResult;
        }

        public async Task<bool> ChangePasswordAsync(string email, string currentPassword, string newPassword)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null) return false;

            user.SetUpdatedDate();

            var identityResult = await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);

            var result = identityResult.Succeeded;

            return result;
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _userManager.Users.ToListAsync();
        }

        public async Task<User> FindUserByEmailAsync(string email)
        {
            return await _userManager.Users.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<User> FindUserByIdAsync(Guid idUser)
        {
            return await _userManager.Users.FirstOrDefaultAsync(x => x.Id == idUser.ToString());
        }

        public async Task UpdateUserAsync(User user)
        {
            user.SetUpdatedDate();

            await _userManager.UpdateAsync(user);
        }
    }
}
