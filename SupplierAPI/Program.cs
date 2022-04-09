using Microsoft.EntityFrameworkCore;
using InventoryAPI.Data;
using InventoryAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<SupplierDBContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ISupplierService, SupplierService>();
builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
DBInitializer.Initializer(app.Services.CreateScope().ServiceProvider.GetRequiredService<SupplierDBContext>());
app.UseAuthorization();

app.MapControllers();

app.Run();
