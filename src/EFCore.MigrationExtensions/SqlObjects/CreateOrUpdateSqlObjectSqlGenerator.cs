using EFCore.MigrationExtensions.Generation;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.MigrationExtensions.SqlObjects;

internal sealed class CreateOrUpdateSqlObjectSqlGenerator : CustomSqlGeneratorBase<CreateOrUpdateSqlObjectOperation>
{
    protected override void Generate(CreateOrUpdateSqlObjectOperation operation, MigrationCommandListBuilder builder)
    {
        builder.Append(operation.SqlCode).EndCommand();
    }
}