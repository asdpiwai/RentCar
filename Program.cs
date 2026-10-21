using Microsoft.EntityFrameworkCore;
using Rentcar.Data;
using Rentcar.Models.Entities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<RentcarDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();


app.Run();