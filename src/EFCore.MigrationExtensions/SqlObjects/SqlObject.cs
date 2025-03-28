namespace EFCore.MigrationExtensions.SqlObjects;

/// <summary> Some SQL object represented by SQL code </summary>
/// <param name="Name">Name of object</param>
/// <param name="SqlCode">Code of object</param>
public record SqlObject(string Name, string SqlCode)
{
    /// <summary> Order in which object is created / updated </summary>
    public int Order { get; init; } = int.MaxValue;
}