using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql.Replication;
using webapiLearn.Data;
using webapiLearn.Dtos;
using webapiLearn.Endpoints;
using webapiLearn.Models.Data;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
var Configuration = builder.Configuration;
builder.Services.AddDbContext<DapperDbContext>(options =>
        options.UseNpgsql(Configuration.GetConnectionString("dqdb"),
        x => x.MigrationsHistoryTable("_EfMigrations", Configuration.GetSection("Schema").GetSection("YourDataSchema").Value)));

builder.Services.AddSqlite<GamesStoreContext>(Configuration.GetConnectionString("GameStore"));

builder.Services.AddTransient<DapperStraightContext>();
builder.Services.AddScoped<DapperStraightContextdqdb>();
builder.Services.AddScoped<DapperContextMssql>();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.


app.UseHttpsRedirection();

//app.UseAuthorization();
app.MapGamesEndpoints();
app.MapGamesEndpointsContext();
app.MapGenresEndpoints();

app.MapControllers();

app.Run();
