using BlazorServerDemo;
using BlazorServerDemo.Middleware;
using DataAccess;
using DataAccess.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.RegisterDependancies();
builder.Services.AddScoped<RouteLogging>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    using var scope = app.Services.CreateScope();
    var users = scope.ServiceProvider.GetRequiredService<IUserService>();
    users.PopulateDbUsers();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseMiddleware<RouteLogging>();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
