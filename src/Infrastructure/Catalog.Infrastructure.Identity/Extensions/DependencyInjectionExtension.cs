using Catalog.Infrastructure.Identity.Contexts;
using Catalog.Infrastructure.Identity.Interfaces;
using Catalog.Infrastructure.Identity.Languages;
using Catalog.Infrastructure.Identity.Models;
using Catalog.Infrastructure.Identity.Repositories;
using Catalog.Infrastructure.Identity.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Catalog.Infrastructure.Identity.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static void AddInfraIdentity(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<IdentityContext>(options => options.UseSqlServer(connectionString));

            services.AddIdentity<User, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedEmail = true;
                options.SignIn.RequireConfirmedAccount = true;

                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                options.User.RequireUniqueEmail = true;
                options.User.AllowedUserNameCharacters =
                    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";

            }).AddEntityFrameworkStores<IdentityContext>()
              .AddDefaultTokenProviders()
              .AddErrorDescriber<CustomIdentityErrorDescriber>();

            services.Configure<DataProtectionTokenProviderOptions>(options =>
                options.TokenLifespan = TimeSpan.FromDays(2));

            services.AddScoped<ITokenService, TokenService>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["Token:SecretKey"])),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddScoped<IIdentityRepository, IdentityRepository>();
        }

        public static async Task ExecuteMigrationIdentityAsync(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<IdentityContext>();

            await context.Database.MigrateAsync();

            await SeedAsync(context);
        }

        private static async Task SeedAsync(IdentityContext context)
        {
            await AddRolesAsync(context);
        }

        private static async Task AddRolesAsync(IdentityContext context)
        {
            var roles = await context.Roles.ToListAsync();

            if (!roles.Any())
            {
                roles.Add(new IdentityRole
                {
                    Name = "Administrador",
                    NormalizedName = "ADMINISTRADOR"
                });

                roles.Add(new IdentityRole
                {
                    Name = "Vendedor",
                    NormalizedName = "VENDEDOR"
                });

                roles.Add(new IdentityRole
                {
                    Name = "Cliente",
                    NormalizedName = "CLIENTE"
                });

                await context.Set<IdentityRole>().AddRangeAsync(roles);

                await context.SaveChangesAsync();
            }
        }
    }
}
