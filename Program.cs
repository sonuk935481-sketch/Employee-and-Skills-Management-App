using Employee_and_Skills_Management_App.Components;
using Employee_and_Skills_Management_App.Data;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

// Add controllers for API endpoints
builder.Services.AddControllers();

// Register employee service for DI
builder.Services.AddScoped<Employee_and_Skills_Management_App.Services.IEmployeeService, Employee_and_Skills_Management_App.Services.EmployeeService>();

// Register HttpClient for server-side use (via IHttpClientFactory)
builder.Services.AddHttpClient();
builder.Services.AddScoped(sp => sp.GetRequiredService<System.Net.Http.IHttpClientFactory>().CreateClient());

// Register services / repositories here if added later

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Antiforgery middleware is required for interactive server render mode endpoints
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Map API controllers
app.MapControllers();

app.Run();
