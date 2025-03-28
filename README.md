# EFCore.MigrationExtensions

[![Version](https://img.shields.io/nuget/vpre/efcore.migrationextensions.svg)](https://www.nuget.org/packages/EFCore.MigrationExtensions)

Adds views, synonyms, stored procedures, etc. (so-called SQL objects) to the EF model. Creates migrations, when those objects are changed.
SQL objects are defined as raw SQL in C#-code or in embedded resources. They can be even generated at runtime.

All EF Core model-tracking and application features are supported:
* When SQL-objects change, migrations are generated.
* SQL-objects are applied on `Database.Migrate()` or `Database.EnsureCreated()`.
* Correct script is generated on `dotnet ef migrations script`.
* Database is updated on `dotnet ef database update`.

# How to use

* Call `UseSqlObjects`:
    * either in [`builder.Services.AddDbContext`](src/TestEntryPoint/Program.cs) and [`DesignTimeDbContextFactory`](src/TestDataAccessLayer/DesignTimeDbContextFactory.cs)
    * or in [`DbContext.OnConfiguring`](src/TestDataAccessLayer/TestContext.cs)
* Create an empty [`DbDesignTimeServices`](src/TestEntryPoint/DbDesignTimeServices.cs) in your entry point. The class should inherit from `CustomNpgsqlDesignTimeServices`
* Add SqlObjects to your context in [`DbContext.OnModelCreating`](src/TestDataAccessLayer/TestContext.cs)
* Generate migrations / scripts / update DB as usual

## Ways to add SqlObjects to the model

```csharp
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    //...

    // Add SqlObject directly
    // Order is used to define the order in which objects are created / updated in DB
    const string Sql = "create or replace view migr_ext_tests.v_view_10 as select * from migr_ext_tests.my_table;";
    modelBuilder.AddSqlObjects(new SqlObject(Name: "v_view_10", SqlCode: Sql) { Order = 10 });

    // Add all embedded resources, placed in assembly's "Sql" folder
    // Only *.sql resources are added
    // There is no way to define order for embedded objects
    // Use resources' names if you need to sort objects
    modelBuilder.AddSqlObjects(assembly: typeof(Class1).Assembly, folder: "Sql");
}
```

# Known limitations
- Doesn't drop deleted objects (generates non compilable code, so the developer should write drop-code himself)
- PostgreSQL and SqlServer are supported, but any other DB can be easily added (use [`EFCore.MigrationExtensions.PostgreSQL`](src/EFCore.MigrationExtensions.PostgreSQL) as an example)
- Needs the same line endings settings for all developers by .gitattributes file or 'git config --global core.autocrlf' command

# Testing
1. Open TestDataAccessLayer folder in terminal
2. Set connection string at TestEntryPoint/appsettings.json
3. Install dotnet-ef
  * `dotnet tool restore`
4. Use the following commands to add migrations / update DB
  * `dotnet dotnet-ef migrations add MyMigr --context TestContext --project TestDataAccessLayer.csproj --startup-project ../TestEntryPoint/TestEntryPoint.csproj`
  * `dotnet dotnet-ef database update --context TestContext --project TestDataAccessLayer.csproj --startup-project ../TestEntryPoint/TestEntryPoint.csproj`
  * `dotnet dotnet-ef migrations script TestMigr Meetup1 --context TestContext --project TestDataAccessLayer.csproj --startup-project ../TestEntryPoint/TestEntryPoint.csproj`
