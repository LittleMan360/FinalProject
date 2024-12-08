using FinalProject.Data;
using Microsoft.EntityFrameworkCore;
using NSwag.AspNetCore; // Add this using directive
using NSwag.Generation.Processors.Security; // Add this using directive

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<FinalProjectContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApiDocument(config =>
{
    config.PostProcess = document =>
    {
        document.Info.Version = "v1";
        document.Info.Title = "API";
        document.Info.Description = "A simple ASP.NET Core web API";
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi(); // This line requires the NSwag.AspNetCore namespace
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
