using Microsoft.EntityFrameworkCore;
using WishList.DataBase;
using WishList.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<WishListDbContext>(
    x => x.UseNpgsql(builder.Configuration.GetConnectionString("WishListApiDatabase"))
    );
builder.Services.AddScoped<IWishListDbContext, WishListDbContext>();
builder.Services.AddScoped<IWishService, WishService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
