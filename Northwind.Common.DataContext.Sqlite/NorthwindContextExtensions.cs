using Microsoft.EntityFrameworkCore; // UseSqlite
using Microsoft.Extensions.DependencyInjection; // IServiceCollection
namespace Packt.Shared;
public static class NorthwindContextExtensions
{
 public static IServiceCollection AddNorthwindContext(
 this IServiceCollection services, string relativePath = "..")
    {
        string databasePath = Path.Combine(relativePath, "Northwind.db");

        services.AddDbContext<NorthwindContext>(options =>
        options.UseSqlite($"Data Source={databasePath}"));

        return services;
    }
}
