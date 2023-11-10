using Microsoft.OpenApi.Models;
using System.Net.Http.Headers;
using System.Text;
using TomsoftLuceed.IServices;
using TomsoftLuceed.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Tomsoft-Luceed Api", Version = "v1" });
    c.EnableAnnotations();
});

IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

#region Authorization to LuceedApi service

using var httpClient = new HttpClient();
var credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{configuration["Authentication:UserName"]}:{configuration["Authentication:Password"]}"));

builder.Services.AddHttpClient("LuceedApiClient", client =>
{
    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);
    client.DefaultRequestHeaders.Add("Accept", "application/json;charset=UTF-8");
});

#endregion

builder.Services.AddScoped<ITomsoftLuceedService, TomsoftLuceedService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
