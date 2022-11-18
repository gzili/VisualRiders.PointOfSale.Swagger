using System.Reflection;
using VisualRiders.PointOfSale.Project.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();