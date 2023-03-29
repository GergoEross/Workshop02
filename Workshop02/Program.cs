using Microsoft.EntityFrameworkCore;
using Workshop02.Data;
using Workshop02.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddOutputCaching();
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IFoodRepository, FoodRepository>();
builder.Services.AddTransient<TableBuilder>();
builder.Services.AddDbContext<FoodDbContext>(opt =>
{
    opt.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=FoodDb;Trusted_Connection=True;MultipleActiveResultSets=true");
    //opt.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=FoodDb;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseExceptionHandler("/Home/Error");
app.UseOutputCaching();
app.UseStaticFiles();
app.UseRouting();
app.MapControllers();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
