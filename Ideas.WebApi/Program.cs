using Ideas.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Ideas.WebApi.Repository;
using Ideas.WebApi.Mappings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<PRT_IDEAsContext>(item => item.UseSqlServer(builder.Configuration.GetConnectionString("IdeasDBConnection")));
builder.Services.AddScoped<IRepository, Repository>();
//builder.Services.AddAutoMapper(typeof(MappingProfile));
    
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
