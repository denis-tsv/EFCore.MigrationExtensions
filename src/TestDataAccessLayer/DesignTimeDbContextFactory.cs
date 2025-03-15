using System;
using EFCore.MigrationExtensions.PostgreSQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TestDataAccessLayer;

internal class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<TestContext>
{
    public TestContext CreateDbContext(string[] args)
    {
        Console.WriteLine($"Using DesignTimeDbContextFactory");

        var builder = new DbContextOptionsBuilder<TestContext>();

        builder.UseSqlObjects();

        builder.UseNpgsql("Host=localhost;Port=5432;Database=efcore_migration_extensions;Username=postgres;Password=postgres;");

        return new TestContext(builder.Options);
    }
}