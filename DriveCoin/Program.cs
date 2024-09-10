using Domain.DIConfiguration;
using Domain.Helpers;
using Domain.Interfaces;
using Domain.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IMapService, MapService>();
builder.Services.AddScoped<ICityService, CityService>();
builder.Services.AddScoped<IRouteService, RouteService>();
builder.Services.AddScoped<ITransportService, TransportService>();
builder.Services.AddScoped<IVehicleService, VehicleService>();

builder.Services.AddMediatr(builder.Configuration);

builder.Services.AddDbContext(builder.Configuration);

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
