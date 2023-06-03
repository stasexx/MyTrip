using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using API.Controllers;
using API.Services;
using API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
    });
});

// Add services to the container.
builder.Services.AddSession();
builder.Services.AddControllers();
builder.Services.AddTransient<IUserService, UserServices>();
builder.Services.AddTransient<ITourService, TourServices>();
builder.Services.AddTransient<IGoogleOAuthService, GoogleOAuthService>();
builder.Services.AddTransient<IGoogleService, GoogleService>();
builder.Services.AddTransient<IWishListService, WishListService>();
builder.Services.AddTransient<IReviewService, ReviewService>();
builder.Services.AddTransient<IHandTourService, HandTourService>();
builder.Services.AddTransient<IOrgTourService, OrgTourService>();
builder.Services.AddTransient<IChatService, ChatService>();
builder.Services.AddTransient<ITourPhotosService, TourPhotosService>();
builder.Services.AddTransient<IFriendsService, FriendsService>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<ISubMembershipService, SubMembershipService>();
builder.Services.AddTransient<IAdminService, AdminService>();
builder.Services.AddDistributedMemoryCache();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(opt =>
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", policy =>
    {
        policy.AllowAnyMethod().AllowAnyHeader().WithOrigins("http://localhost:3000");
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("CorsPolicy");


app.UseCors();

app.UseHttpsRedirection();

app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseSession();

app.MapControllers();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;

try
{
    var contex = services.GetRequiredService<DataContext>();
    await contex.Database.MigrateAsync();
    await Seed.SeedDataUsers(contex);
    await Seed.SeedDataTours(contex);
}
catch (Exception ex)
{
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error occured during migration!!!");
}

app.Run();
