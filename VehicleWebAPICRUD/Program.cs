using Microsoft.EntityFrameworkCore;
using VehicleWebAPICRUD.Interfaces;
using VehicleWebAPICRUD.Services;
using VehicleWebAPICRUD.VehicleDBContext;




var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DbContext (IMPORTANT: configure connection string)
builder.Services.AddDbContext<db_context>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("SqlServerConn")
    )
);

// Dependency Injection
builder.Services.AddScoped<IVehicleService, VehicleService>();

var app = builder.Build();

// Enable Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Student API v1");
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();