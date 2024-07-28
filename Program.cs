using Microsoft.EntityFrameworkCore;
using Registrar.Data;
using Registrar.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
    new MySqlServerVersion(new Version(8, 0, 21))));

builder.Services.AddControllers();
builder.Services.AddSignalR();

builder.Services.AddAntiforgery(options =>
{
    options.HeaderName = "X-XSRF-TOKEN";
});

string baseAddress = builder.Configuration["BaseAddress"];
if (string.IsNullOrEmpty(baseAddress))
{
    throw new InvalidOperationException("Base address not found in configuration.");
}

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(baseAddress) });

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.MapHub<RegistrationHub>("/registrationHub");

app.Run();
