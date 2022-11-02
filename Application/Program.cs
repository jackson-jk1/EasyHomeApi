
using Application.Configurations;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Application.Middleware;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();

// AutoMapper 
builder.Services.AddAutoMapperConfiguration();

builder.Services.AddDbContext<MySqlContext>(options =>
{
    var server = builder.Configuration["Database:mysql:server"];
    var port = builder.Configuration["Database:mysql:port"];
    var Database = builder.Configuration["Database:mysql:database"];
    var username = builder.Configuration["Database:mysql:username"];
    var password = builder.Configuration["Database:mysql:password"];
    var ConectionString = $"Server={server};Port={port};Database={Database};Uid={username};Pwd={password}";

    options.UseMySql(ConectionString, ServerVersion.AutoDetect(ConectionString), opt =>
    {
        opt.CommandTimeout(180);
   
    });
});


// HttpClient 
builder.Services.AddHttpClient();


builder.Services.AddSwaggerGen();

// Injeno de Dependecias
builder.Services.AddDependencyInjectionConfiguration();



//TODO: Validar front _total no response header
builder.Services.AddCors(config =>
{
    var policy = new CorsPolicy();
    policy.Headers.Add("*");
    policy.Methods.Add("*");
    policy.Origins.Add("*");
    policy.SupportsCredentials = true;
    config.AddPolicy("policy", policy);
});

builder.Configuration.AddJsonFile("appsettings.json");


var app = builder.Build();



if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


//app.UseMiddleware<HandlingMiddleware>();
app.UseMiddleware<JwtMiddleware>();

app.UseStaticFiles();

app.UseRouting();

app.UseHttpsRedirection();

app.MapControllers();


app.Run();
