using System.Reflection;
using Microsoft.OpenApi.Models;
using VisualRiders.PointOfSale.Project.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Point of Sale API",
        Description = "Point of Sale API designed by Visual Riders according to the requirements document by Sherlock Homies.",
        Contact = new OpenApiContact
        {
            Name = "GitHub repository",
            Url = new Uri("https://github.com/gzili/VisualRiders.PointOfSale")
        }
    });
    
    options.EnableAnnotations();
    
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

builder.Services.AddScoped<PermissionsRepository>();
builder.Services.AddScoped<ProductsRepository>();
builder.Services.AddScoped<DiscountsRepository>();
builder.Services.AddScoped<PurchasableItemsRepository>();
builder.Services.AddScoped<ItemCategoriesRepository>();
builder.Services.AddScoped<CustomersRepository>();
builder.Services.AddScoped<ServicesRepository>();
builder.Services.AddScoped<RolesRepository>();
builder.Services.AddScoped<BranchesRepository>();
builder.Services.AddScoped<CompaniesRepository>();
builder.Services.AddScoped<ReservationsRepository>();
builder.Services.AddScoped<OrdersRepository>();
builder.Services.AddScoped<EmployeesRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();