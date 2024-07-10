
using EmployeeManagementSystemApi.Core.Repository;
using EmployeeManagementSystemApi.Core.Repository.AttendanceRepo;
using EmployeeManagementSystemApi.Core.Repository.EmployeeRepo;
using EmployeeManagementSystemApi.Core.Service.Attendance;
using EmployeeManagementSystemApi.Core.Service.EmployeeService;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddFluentValidation(c => c.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddDbContext<ApplicationDbContext>(options=>options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IEmployeeRepo, EmployeeRepo>();
builder.Services.AddScoped<IAttendanceRepo, AttendanceRepo>();
builder.Services.AddScoped<IEmployeeService , EmployeeService>();
builder.Services.AddScoped<IAttendanceService, AttendanceService>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors(policy=>policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
app.MapControllers();

app.Run();
