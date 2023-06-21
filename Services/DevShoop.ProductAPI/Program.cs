using DevShoop.ProductAPI;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services
       .AddEndpointsApiExplorer()
       .AddSwaggerGen()
       .AddSingleton(MappingConfig.RegisterMaps().CreateMapper())
       .AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies())
       .AddScoped<IProductRepository, ProductRepository>();

var connection = builder.Configuration.GetConnectionString("MySQLConnectionString");
builder.Services.AddDbContext<ProductApiContext>(options =>
    options.UseMySql(connection, new MySqlServerVersion(new Version(8, 0, 23))));

var app = builder.Build();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
    
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();