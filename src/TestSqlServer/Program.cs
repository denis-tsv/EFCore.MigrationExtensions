using EFCore.MigrationExtensions.SqlServer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestSqlServer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<TestContext>(options =>
{
    options.UseSqlObjects();
    
    options.UseSqlServer(builder.Configuration.GetConnectionString("MigrationExtensions"));
});

var app = builder.Build();

app.Run();