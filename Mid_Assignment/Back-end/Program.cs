using Back_end.Context;
using Microsoft.EntityFrameworkCore;
using Back_end.Services;
using Back_end.Entities;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var service = builder.Services;


service.AddDbContext<LibraryContext>( 
    options =>   {options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    
    } 
    
);

service.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
service.AddTransient<IService<Book>,BookService>();

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
