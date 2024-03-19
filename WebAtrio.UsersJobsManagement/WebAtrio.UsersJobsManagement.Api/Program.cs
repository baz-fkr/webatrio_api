using Microsoft.EntityFrameworkCore;
using WebAtrio.UsersJobsManagement.Business;
using WebAtrio.UsersJobsManagement.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<IJobService, JobService>();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IJobRepository, JobRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure the database
var configuration = builder.Configuration;
builder.Services.AddDbContext<UJDbContext>(options =>
    options.UseNpgsql(configuration.GetConnectionString("Database")));


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
