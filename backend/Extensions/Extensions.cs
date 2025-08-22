using Microsoft.EntityFrameworkCore;


using backend.Services;
using backend.Interfaces;
using backend.Models;

namespace backend.Extensions;

public static class Extensions
{
    public static void AddApplicationServices(this IHostApplicationBuilder builder)
    {

        string connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new Exception("DB_CONNECTION_STRING is not set.");

        builder.Services.AddDbContext<ApiDbContext>(opt => opt.UseNpgsql(connectionString).UseSnakeCaseNamingConvention());

        builder.Services.AddScoped<ICategoryService, CategoryService>();
        builder.Services.AddScoped<IProductService, ProductService>();
        builder.Services.AddScoped<ITokenService, TokenService>();
    }
}