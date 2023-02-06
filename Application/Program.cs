
using Application.Configurations;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Application.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Linq;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics.Metrics;
using System.Reflection.Metadata;

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

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "EasyHome Api", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                          {
                              Reference = new OpenApiReference
                              {
                                  Type = ReferenceType.SecurityScheme,
                                  Id = "Bearer"
                              }
                          },
                         new string[] {}
                    }
                });
});

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
