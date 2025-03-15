using EFCore.MigrationExtensions.Generation;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.MigrationExtensions.SqlObjects;

internal sealed class DropSqlObjectSqlGenerator : CustomSqlGeneratorBase<DropSqlObjectOperation>
{
    protected override void Generate(DropSqlObjectOperation operation, MigrationCommandListBuilder builder)
    {
        builder.Append(operation.SqlCode).EndCommand();
    }
}