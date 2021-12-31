using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RecipeManagerWeb.Data;

var builder = WebApplication.CreateBuilder(args);

// Add db configuration

builder.Services.AddDbContext<DataContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.

builder.Services.AddControllersWithViews();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Repositories

builder.Services.AddScoped<IGroceryCategoryRepository, GroceryCategoryRepository>();
builder.Services.AddScoped<IGroceryItemRepository, GroceryItemRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
