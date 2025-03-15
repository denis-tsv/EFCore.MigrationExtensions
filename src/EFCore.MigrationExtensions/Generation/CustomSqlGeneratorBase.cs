using System;
using EFCore.MigrationExtensions.Generation.Contracts;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.MigrationExtensions.Generation;

internal abstract class CustomSqlGeneratorBase<T> : ICustomSqlGenerator
    where T : CustomMigrationOperation
{
    public Type OperationType => typeof(T);

    public void Generate(CustomMigrationOperation operation, MigrationCommandListBuilder builder)
    {
        if (operation is T typedOperation)
        {
            Generate(typedOperation, builder);
            return;
        }

        throw new InvalidOperationException(
            $"Ожидался тип операции {typeof(T).Name}, но получен {operation.GetType()}");
    }

    protected abstract void Generate(T operation, MigrationCommandListBuilder builder);
}