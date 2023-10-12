using Microsoft.EntityFrameworkCore;
using ProductAPI.Context;
using ProductAPI.Extensions;
using ProductAPI.Services;
using ProductAPI.Services.Interfaces;

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

// register automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IProductInterface, ProductService>();

builder.Services.AddCors(options => options.AddPolicy("mypolicy", build =>
{
  build.AllowAnyOrigin();
  build.AllowAnyMethod();
  build.AllowAnyHeader();
}));

builder.AddSwaggenGenExtension();
builder.AddAppAuthentication();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseMigration();
app.UseAuthorization();
app.UseCors("mypolicy");

app.MapControllers();

app.Run();
