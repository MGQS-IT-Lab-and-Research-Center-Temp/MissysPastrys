using Microsoft.EntityFrameworkCore;
using MissysPastrys.Context;
using MissysPastrys.Repository.Implementations;
using MissysPastrys.Repository.Interfaces;
using MissysPastrys.Service.Implementations;
using MissysPastrys.Service.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IPastryRepository, PastryRepository>();


builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<MissysPastrysDbContext>(option =>
    option.UseMySQL(builder.Configuration.GetConnectionString("MissysPastrysDbContext")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
