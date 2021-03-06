using Back_end.Context;
using Microsoft.EntityFrameworkCore;
using Back_end.Services;
using Back_end.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var service = builder.Services;


service.AddDbContext<LibraryContext>(
    options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

    }

);

service.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
service.AddTransient<IService<Book>, BookService>();
service.AddTransient<IService<Category>, CategoryService>();
service.AddTransient<IService<User>, UserService>();
service.AddTransient<IService<BookBorrowingRequest>, RequestService>();
service.AddTransient<IAuthorizecation,Authorizecation>();

service.AddAuthentication(x => {
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme =  JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x=>{
    x.RequireHttpsMetadata =false;
    x.SaveToken = true;
   
});


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}
  app.UseCors(builder => builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
 );

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseAuthorization();
app.MapControllers();

app.Run();
