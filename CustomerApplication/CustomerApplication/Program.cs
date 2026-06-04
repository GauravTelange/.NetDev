using CustomerApplication.Routing;
using CustomerApplication.Dal;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IDal, EfDal>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Customer/LoadCustomer"); // or add a real error page
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();      // before UseRouting
app.UseRouting();
app.UseAuthorization();

// Specific routes first
Routing.loadRoutes(app);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Customer}/{action=LoadCustomer}/{id?}");

app.Run();