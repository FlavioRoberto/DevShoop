using DevShoop.ProductAPI.Config;
using DevShoop.ProductAPI.Application.Config;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services
       .AddEndpointsApiExplorer()
       .AddSwaggerGen()
       .AddSingleton(MappingConfig.RegisterMaps().CreateMapper())
       .AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies())
       .AddDependency(builder.Configuration);

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