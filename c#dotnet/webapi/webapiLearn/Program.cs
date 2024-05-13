using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using webapiLearn.Models.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var Configuration = builder.Configuration;
builder.Services.AddDbContext<DapperDbContext>(options =>
        options.UseNpgsql(Configuration.GetConnectionString("dqdb"),
        x => x.MigrationsHistoryTable("_EfMigrations", Configuration.GetSection("Schema").GetSection("YourDataSchema").Value)));

builder.Services.AddTransient<DapperStraightContext>();
builder.Services.AddScoped<DapperStraightContextdqdb>();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.


app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();
