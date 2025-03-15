using EFCore.MigrationExtensions.SqlObjects;
using Microsoft.EntityFrameworkCore;

namespace TestSqlServer;

public class TestContext : DbContext
{
    public TestContext(DbContextOptions<TestContext> options) : base(options)
    {
    }

    public DbSet<Class1> Classes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.AddSqlObjects(assembly: typeof(Class1).Assembly, folder: "Sql");
    }
}