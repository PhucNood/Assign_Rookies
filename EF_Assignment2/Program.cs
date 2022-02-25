using EF_Assignment2.Context;
using Microsoft.EntityFrameworkCore;
using EF_Assignment2.Mapper;
using EF_Assignment2.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var service = builder.Services;
service.AddDbContext<ShopContext>(
    options => options.UseSqlServer("Server=LAPTOP-POPERAEM\\SQLEXPRESS; Database=Shop; User Id=sa; Password=sa;")
);
service.AddTransient<IShopService,ShopService>();
service.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
