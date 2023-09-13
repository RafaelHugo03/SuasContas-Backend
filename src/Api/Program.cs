using Infra.Data;
using Microsoft.EntityFrameworkCore;
using Application.Dependencies;
using Infra.DomainDependencies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("SqlConnection");
builder.Services.AddDbContext<DatabaseContext>(opt => opt.UseSqlServer(connectionString));
builder.Services.InjectApplicationDependencies();
builder.Services.InjectDependencies();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(opt => opt.AllowAnyOrigin());

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
