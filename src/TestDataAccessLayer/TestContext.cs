using EFCore.MigrationExtensions.SqlObjects;
using Microsoft.EntityFrameworkCore;

namespace TestDataAccessLayer;

public class TestContext : DbContext
{
    public TestContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasDefaultSchema("migr_ext_tests");
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(Class1Configuration).Assembly);

        // Add SqlObject directly
        const string Sql = "create or replace view migr_ext_tests.v_view_10 as select * from migr_ext_tests.my_table;";
        modelBuilder.AddSqlObjects(new SqlObject(Name: "v_view_10", SqlCode: Sql) { Order = 10 });

        // Add all embedded resources, placed in assembly's "Sql" folder
        // Only *.sql resources are added
        modelBuilder.AddSqlObjects(assembly: typeof(Class1).Assembly, folder: "Sql");
    }
}