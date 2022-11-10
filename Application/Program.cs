
using Application.Configurations;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Application.Middleware;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();

// AutoMapper 
builder.Services.AddAutoMapperConfiguration();

builder.Services.AddDbContext<MySqlContext>(options =>
{
    var server = builder.Configuration["SERVER"];
    Console.WriteLine(server);
    var port = builder.Configuration["PORT"];
    var Database = builder.Configuration["DATABASE"];
    var username = builder.Configuration["USERNAME"];
    Console.WriteLine(username);

    var password = builder.Configuration["PASSWORD"];
    var ConectionString = $"Server={server};Port={port};Database={Database};Uid={username};Pwd={password}";
    Console.WriteLine(ConectionString);

    /*options.UseMySql(ConectionString, ServerVersion.AutoDetect(ConectionString), opt =>
    {
        opt.CommandTimeout(180);
   
    });*/
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

/*using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<MySqlContext>();
    if (context.Database.GetPendingMigrations().Any())
    {
        context.Database.Migrate();
    }
}*/

app.Run("https://*:80");
