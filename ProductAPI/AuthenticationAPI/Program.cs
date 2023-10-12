using AuthenticationAPI.Context;
using AuthenticationAPI.Extensions;
using AuthenticationAPI.Models;
using AuthenticationAPI.Services;
using AuthenticationAPI.Services.IServices;
using AuthenticationAPI.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
{
  options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection"));
});

builder.Services.AddCors(options => options.AddPolicy("mypolicy", build =>
{
  build.AllowAnyOrigin();
  build.AllowAnyMethod();
  build.AllowAnyHeader();
}));
//Register IdentityFramework
builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();

// register our services
builder.Services.AddScoped<IUserInterface, UserService>();
builder.Services.AddScoped<IJWTTokenGenerator, JwtService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("JwtOptions"));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseMigration();
app.UseCors("mypolicy");
app.UseAuthorization();
app.MapControllers();

app.Run();
