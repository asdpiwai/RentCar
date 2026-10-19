using Microsoft.EntityFrameworkCore;
using Rentcar.Data;
using Rentcar.Models.Entities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<RentcarDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

async Task<int> CountCategory(RentcarDbContext rentcarDbContext)
{
    var res = await rentcarDbContext.Categories.CountAsync();
    return res;
}

async Task<Category> CreateCategory(RentcarDbContext rentcarDbContext)
{
    Category newCategory = new Category();
    newCategory.Name = "Бизнес";
    newCategory.BasePricePerDay = 100;
    newCategory.Description = "Премиальные автомобили с большим комфортом";
    newCategory.CreatedAt = DateTime.UtcNow;
    rentcarDbContext.Categories.Add(newCategory);
    await rentcarDbContext.SaveChangesAsync();
    return newCategory;
}

async Task<List<Category>> GetCategory(RentcarDbContext rentcarDbContext)
{
    var categories = await rentcarDbContext.Categories.ToListAsync();
    return categories;
}

app.MapGet("/categories/count", CountCategory);
app.MapPost("/categories/test", CreateCategory);
app.MapGet("/categories", GetCategory);

app.Run();