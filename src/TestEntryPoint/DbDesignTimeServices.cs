using EFCore.MigrationExtensions.PostgreSQL;

namespace TestEntryPoint;

/// <summary> EF Core searches for these services at the entry point... </summary>
internal class DbDesignTimeServices : CustomNpgsqlDesignTimeServices
{
}