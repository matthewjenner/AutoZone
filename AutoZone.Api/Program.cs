using System;
using System.Text;
using AutoZone.Api.MappingProfiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using AutoZone.Data;
using AutoZone.Service.Services;
using AutoZone.Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AutoZone.Api;

public static class Program
{
    public static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        // Add DB Configuration
        builder.Services.AddDbContext<AutoZoneDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
                sqlServerOptionsAction: sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure(
                        maxRetryCount: 5,
                        maxRetryDelay: TimeSpan.FromSeconds(30),
                        errorNumbersToAdd: null);
                }));

        // Register repositories
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();

        // Register services
        builder.Services.AddScoped<UserService>();
        builder.Services.AddScoped<IVehicleService, VehicleService>();

        builder.Services.AddHttpContextAccessor();

        // Add CORS
        builder.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(builder =>
            {
                builder
                    .WithOrigins("*")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .WithExposedHeaders("Content-Disposition");
            });
        });

        builder.Services.AddAutoMapper(cfg => { }, typeof(UserProfile), typeof(VehicleProfile));
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();

        var jwtKey = builder.Configuration["Jwt:Key"];
        if (string.IsNullOrEmpty(jwtKey))
        {
            throw new InvalidOperationException("JWT Key is not configured!");
        }

        var jwtIssuer = builder.Configuration["Jwt:Issuer"];

        builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtIssuer,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
                };
            });

        builder.Services.AddHttpClient();

        WebApplication app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            // Migrate and seed DB automatically in dev
            using IServiceScope scope = app.Services.CreateScope();
            AutoZoneDbContext db = scope.ServiceProvider.GetRequiredService<AutoZoneDbContext>();
            db.Database.Migrate();
        }

        app.UseAuthentication();
        app.UseAuthorization();
        app.UseCors();
        app.UseHttpsRedirection();

        app.MapControllers();

        app.Run();
    }
}
