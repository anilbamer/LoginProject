using Microsoft.EntityFrameworkCore;
using WebApplication1;
using WebApplication1.Data.Entities;
using WebApplication1.Repository;
using WebApplication1.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ServiceResult>();
builder.Services.AddScoped<ILogin,LoginData>();
builder.Services.AddScoped<ILoginService,Logininfo>();
//builder.Services.AddDbContext<LoginDbContext>();
builder.Services.AddDbContext<LoginDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
builder.Configuration
         .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
         .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true);
app.UseHttpsRedirection();
app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();

app.Run();
