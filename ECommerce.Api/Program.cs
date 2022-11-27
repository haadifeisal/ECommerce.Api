using ECommerce.Api;
using ECommerce.Api.Repositories.ECommerce;
using ECommerce.Api.Repositories.ECommerce.Data;
using ECommerce.Api.Repositories.ECommerce.Interfaces;
using ECommerce.Api.Services;
using ECommerce.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ECommerceContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetValue<string>(nameof(AppSettings.ECommerceConnectionString)));
});

builder.Services.AddControllers();

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<ECommerceContext>();

context.Database.Migrate();
DbInitializer.Initialize(context);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
