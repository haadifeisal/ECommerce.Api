using ECommerce.Api;
using ECommerce.Api.Repositories.ECommerce;
using ECommerce.Api.Repositories.ECommerce.Data;
using ECommerce.Api.Repositories.ECommerce.Interfaces;
using ECommerce.Api.Services;
using ECommerce.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<AppSettings>(builder.Configuration);

var provider = builder.Services.BuildServiceProvider();
var appSettings = provider.GetRequiredService<IOptions<AppSettings>>();

var allowedOrigins = nameof(appSettings.Value.AllowedOrigins);

builder.Services.AddDbContext<ECommerceContext>(opt =>
{
    opt.UseSqlServer(appSettings.Value.ECommerceConnectionString);
});

builder.Services.AddCors(options =>
{
    options.AddPolicy(allowedOrigins, builder =>
    {
        builder.WithOrigins(appSettings.Value.AllowedOrigins) // .WithOrigins(this.Configuration.GetSection("AllowedOrigins").Get<string[]>()).WithHeaders(...)
            .WithHeaders("accept", "content-type", "oigin", "authorization")
            .AllowAnyMethod();
    });
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

app.UseCors(allowedOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
