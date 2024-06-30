
using Barometer.BLL.MapperProfile;
using Barometer.BLL.Services.Implementation;
using Barometer.BLL.Services.Interface;
using Barometer.DAL.Repositories.Implementation;
using Barometer.DAL.Repositories.Interfaec;
using Barometer.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("BarometerDbConnection");
builder.Services.AddDbContext<BarometerContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddAutoMapper(typeof(Program));
// In your DI configuration or a dedicated configuration class
builder.Services.AddAutoMapper(typeof(BarometerMapperProfile));

builder.Services.AddScoped<IBarometerRepository, BarometerRepository>();
builder.Services.AddScoped<IBarometerService, BarometerService>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
