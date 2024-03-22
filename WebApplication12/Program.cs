using WebApplication12;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder();

string connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));

var app = builder.Build();

app.MapGet("/", async (HttpContext httpContext) =>
{   
    using (var scope = app.Services.CreateScope())
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
        var users = await dbContext.Users.ToListAsync();
        await httpContext.Response.WriteAsJsonAsync(users);
    }
});

app.Run();
