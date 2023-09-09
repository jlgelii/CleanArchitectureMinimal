using CleanArchitecture.API.Configurations.Services;
using CleanArchitecture.API.Endpoints;
using CleanArchitecture.Application;
using CleanArchitecture.Application.Configurations.Database;
using CleanArchitecture.Application.Configurations.Services;
using CleanArchitecture.Domain.Database;
using CleanArchitecture.Infrastructure.Database;
using CleanArchitecture.Infrastructure.Middleware;
using CleanArchitecture.Infrastructure.Services;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Configuration.AppSettingConfigurations();

builder.Services.AddJwt();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwagger();
builder.Services.AddValidators();

builder.Services.AddHttpContextAccessor();
builder.Services.AddMediatR(x => x.RegisterServicesFromAssembly(typeof(EntryPoint).Assembly));
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

builder.Services.AddSingleton<IJwtServices, JwtServices>();
builder.Services.AddSingleton<IDateTimeServices, DateTimeServices>();
builder.Services.AddScoped<IApplicationDatabaseContext, ApplicationDbContext>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapUserAccountEndpoints();
app.MapAuthEndpoints();

app.Run();

