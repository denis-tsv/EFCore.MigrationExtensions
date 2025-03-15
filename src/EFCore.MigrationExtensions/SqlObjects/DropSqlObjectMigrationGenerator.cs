using EFCore.MigrationExtensions.Generation;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace EFCore.MigrationExtensions.SqlObjects;

internal sealed class DropSqlObjectMigrationGenerator : CustomMigrationOperationGeneratorBase<DropSqlObjectOperation>
{
    private readonly ICSharpHelper _code;

    public DropSqlObjectMigrationGenerator(ICSharpHelper code)
    {
        _code = code;
    }

    /// <summary>
    ///     Generates code for an <see cref="DropSqlObjectOperation" />.
    /// </summary>
    protected override void Generate(DropSqlObjectOperation operation, IndentedStringBuilder builder)
    {
        builder.AppendLine($".{nameof(MigrationBuilderSqlObjectsExtensions.DropSqlObject)}(");
        using (builder.Indent())
        {
            builder.Append("name: ").Append(_code.Literal(operation.Name)).AppendLine(",");
            builder.Append("sqlCode: ").Append($"DROP {operation.Name}").AppendLine(", // write code to drop object");
            builder.Append("order: ").Append(_code.Literal(operation.Order)).Append(")");
        }
    }
}