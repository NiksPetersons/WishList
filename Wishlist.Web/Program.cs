using Microsoft.EntityFrameworkCore;
using WishList.Core.Validations;
using WishList.DataBase;
using WishList.Services;
using Wishlist.Web.AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<WishListDbContext>(
    x => x.UseNpgsql(builder.Configuration.GetConnectionString("WishListApiDatabase"))
    );
//Context
builder.Services.AddScoped<IWishListDbContext, WishListDbContext>();
//Services
builder.Services.AddScoped<IWishService, WishService>();
//AutoMapper
builder.Services.AddSingleton(AutoMapperConfig.MapperConfig());
//Validators
builder.Services.AddScoped<IWishValidator, WishNameValidator>();
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
