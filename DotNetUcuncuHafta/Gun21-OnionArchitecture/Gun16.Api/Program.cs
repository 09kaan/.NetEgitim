using Gun16.Application.Interfaces;
using Gun16.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Gun16.Infrastructure.Repositories;
using Gun16.Application.Services;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddProblemDetails();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    string? connectionString =
        builder.Configuration.GetConnectionString(
            "DefaultConnection"
        );

    options.UseSqlServer(connectionString);
});

builder.Services.AddOpenApi();

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();


var app = builder.Build();

app.UseExceptionHandler();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
