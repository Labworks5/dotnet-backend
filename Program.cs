
using DotNet_HelloWorld.Models; // ***
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using DotNet_HelloWorld.Data;
using DotNet_HelloWorld;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)); 

}); 


var app = builder.Build();

// Seed Db 
// SeedDatabase();

/*void SeedDatabase()
{
    using(var scope = app.Services.CreateScope())
    try{
        var scopedContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        Seeder.Initialize(scopedContext);

        }
    catch
    {
        throw;
    }
} */

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
