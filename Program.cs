using EKostApi.Data;
using EKostApi.Interface;
using EKostApi.Repository;
using EKostApi.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<EkostContext>(options =>
{
    options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")!);
});

builder.Services.AddScoped<IAccount, AccountRepo>();
builder.Services.AddScoped<IRole, RoleRepo>();
builder.Services.AddScoped<IKostType, KostTypeRepo>();
builder.Services.AddScoped<IKost, KostRepo>();

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
