using System.Text.Json.Serialization;
using Dapper;
using Microsoft.OpenApi.Models;
using TurnApi.DapperHandler;
using TurnApi.Repositories;
using TurnApi.Repositories.Interface;
using TurnApi.Services;
using TurnApi.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen(c =>
{
    c.MapType<DateOnly>(() => new OpenApiSchema
    {
        Type = "string",
        Format = "date"
    });

    c.MapType<TimeOnly>(() => new OpenApiSchema
    {
        Type = "string",
        Format = "time"
    });
});

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(
            new JsonStringEnumConverter()
        );
    });

// Add services to the container.
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<IAgendaService, AgendaService>();

// Add repositories to the container.
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<IAgendaRepository, AgendaRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionSql = builder.Configuration["ConnectionStrings:SQLSERVER"];
SqlMapper.AddTypeHandler(new SqlTimeOnlyTypeHandler());
SqlMapper.AddTypeHandler(new SqlDateOnlyTypeHandler());


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
