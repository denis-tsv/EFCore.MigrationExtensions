using EFCore.MigrationExtensions.SqlServer;

namespace TestSqlServer;

/// <summary> EF Core searches for these services at the entry point... </summary>
internal class DbDesignTimeServices : CustomSqlServerDesignTimeServices
{
}