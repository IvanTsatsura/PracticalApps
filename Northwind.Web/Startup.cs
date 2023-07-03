using Packt.Shared;
using static System.Console;

namespace Northwind.Web;
public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddRazorPages();
        services.AddNorthwindContext();
    }
    public void Configure(
    IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (!env.IsDevelopment())
        {
            app.UseHsts();
        }
        app.UseRouting(); // начало маршрутизации конечной точки

        app.Use(async (HttpContext context, Func<Task> next) =>
        {
            RouteEndpoint? rep = context.GetEndpoint() as RouteEndpoint;
            if (rep is not null)
            {
                WriteLine($"Endpoint name: {rep.DisplayName}");
                WriteLine($"Endpoint route pattern: {rep.RoutePattern.RawText}");
            }
            if (context.Request.Path == "/bonjour")
            {
                // в случае совпадения URL-пути становится возвращаемым 
                // завершающим делегатом, поэтому следующий делегат
                // не вызывается
                await context.Response.WriteAsync("Bonjour Monde!");
                return;
            }
            // можно изменить запрос перед вызовом следующего делегата
            await next();
            // можно изменить ответ после вызова следующего делегата
        });

        app.UseHttpsRedirection();

        app.UseDefaultFiles(); // index.html, default.html и т.п.
        app.UseStaticFiles();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapRazorPages();

            endpoints.MapGet("/hello", () => "Hello World!");
        });
    }
}