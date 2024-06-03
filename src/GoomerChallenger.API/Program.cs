using GoomerChallenger.API.Controller;
using GoomerChallenger.API.Extension;
using GoomerChallenger.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpContextAccessor();
builder.Services.AddContext(builder.Configuration);
builder.AddDependencies();
//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

//builder.Services.AddDbContext<GoomerContext>(options =>
//    options.UseNpgsql(connectionString));


var app = builder.Build();
var mapGroup = app.MapGroup("v1");

mapGroup.AddRestauranteRoutes();
//mapGroup.AddLoginRoutes();
//mapGroup.AddLocalityRoutes();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();



app.Run();