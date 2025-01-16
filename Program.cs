using Microsoft.EntityFrameworkCore;
using HEWalks.API.Data;
using Microsoft.Extensions.Options;
using HEWalks.API.Repositories;
using HEWalks.API.Mappings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//injecting the DbContext
builder.Services.AddDbContext<HEWalksDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("HEWalksConnectionString")));

//Injecting the repository
builder.Services.AddScoped<IRegionRepository, SQLRegionRepository>();
builder.Services.AddScoped<IWalkRepository, SQLWalkRepository>();

// Injecting AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

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
