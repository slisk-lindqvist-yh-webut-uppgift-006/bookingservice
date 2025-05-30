using Application.Interfaces;
using Application.Services;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(x =>
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection")));
builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddScoped<IBookingOwnerRepository, BookingOwnerRepository>();
builder.Services.AddScoped<IBookingAddressRepository, BookingAddressRepository>();
builder.Services.AddScoped<IBookingService, BookingService>();

var app = builder.Build();
app.MapOpenApi();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Event Service API");
    c.RoutePrefix = string.Empty;
});


app.UseHttpsRedirection();
app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();