using AspNetCoreHero.ToastNotification;
using AspNetCoreHero.ToastNotification.Extensions;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using MissysPastrys.Context;
using MissysPastrys.Entities;
using MissysPastrys.Repository.Implementations;
using MissysPastrys.Repository.Interfaces;
using MissysPastrys.Service.Implementations;
using MissysPastrys.Service.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IDeliveryRepository, DeliveryRepository>();
builder.Services.AddScoped<IDeliveryService, DeliveryService>();
builder.Services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IPastryRepository, PastryRepository>();
builder.Services.AddScoped<IPastryService, PastryService>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
builder.Services.AddScoped<IReviewService, ReviewService>();
builder.Services.AddScoped<IShoppingCartService, ShoppingCartService>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ShoppingCart>();

builder.Services.AddSession();
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddNotyf(config =>
{
    config.DurationInSeconds = 10;
    config.IsDismissable = true;
    config.Position = NotyfPosition.TopRight;
});

builder.Services.AddDbContext<MissysPastrysDbContext>(option =>
    option.UseMySQL(builder.Configuration.GetConnectionString("MissysPastrysDbContext")));
builder.Services.AddScoped<DbInitializer>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(config =>
{
    config.LoginPath = "/home/login";
    config.Cookie.Name = "MissysPastrys";
    config.ExpireTimeSpan = TimeSpan.FromHours(1);
    config.AccessDeniedPath = "/home/privacy";
});

builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.SeedToDatabase();
app.UseRouting();
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();
app.UseNotyf();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Login}/{id?}");

app.Run();
