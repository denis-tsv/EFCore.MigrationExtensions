using EFCore.MigrationExtensions.PostgreSQL;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestDataAccessLayer;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<TestContext>(options =>
{
    options.UseSqlObjects();
    
    options.UseNpgsql(builder.Configuration.GetConnectionString("MigrationExtensions"));
});

var app = builder.Build();

app.Run();