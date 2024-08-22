using Microsoft.EntityFrameworkCore;
using Registrar.Data;
using Registrar.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add Razor Pages, Blazor, and Entity Framework Core
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
    new MySqlServerVersion(new Version(8, 0, 21))));

// Add Controllers and SignalR
builder.Services.AddControllers();
builder.Services.AddSignalR();

// Add Anti-forgery tokens
builder.Services.AddAntiforgery(options =>
{
    options.HeaderName = "X-XSRF-TOKEN";
});

// Base Address Configuration
string baseAddress = builder.Configuration["BaseAddress"];
if (string.IsNullOrEmpty(baseAddress))
{
    throw new InvalidOperationException("Base address not found in configuration.");
}

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(baseAddress) });

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
else
{
    // Disable HTTPS Redirection in Development or Docker Environment
    // Comment out this line if you want to test HTTPS locally
    // app.UseHttpsRedirection();
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.MapHub<RegistrationHub>("/registrationHub");

app.Run();
