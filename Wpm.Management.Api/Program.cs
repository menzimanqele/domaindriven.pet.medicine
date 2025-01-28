using Microsoft.EntityFrameworkCore;
using Wpm.Management.Api.Infrastructure;
using Wpm.Management.Domain.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IBreedService, BreedService>();
builder.Services.AddScoped<IManagementRepository, ManagementRepository>();
builder.Services.AddDbContext<ManagementDbContext>(options =>
{
    options.UseSqlite("Data Source=WpmManagement.db");
});

var app = builder.Build();
app.EnsureDbIsCreated();

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
