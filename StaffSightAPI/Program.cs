using Microsoft.EntityFrameworkCore;
using StaffSightAPI.Data;
using StaffSightAPI.Models;
using StaffSightAPI.Repositories.Implementation;
using StaffSightAPI.Repositories;
using StaffSightAPI.Services;
using StaffSightAPI.Repositories.Implementations;
using StaffSightAPI.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.WithOrigins("http://localhost:4200")  // Assuming your Angular app is running on this domain
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("StaffSightConnection")));


builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IEmployeeSalOffHistService, EmployeeSalOffHistService>();
builder.Services.AddScoped<IEmployeeNoteService, EmployeeNoteService>();
builder.Services.AddScoped<IEmployeeLeaveService, EmployeeLeaveService>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IPreFillRepository, PreFillRepository>();
builder.Services.AddScoped<IPreFillService, PreFillService>();
builder.Services.AddScoped<IEmployeePreHireService, EmployeePreHireService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();  // Use CORS here

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
