using System;
using EFCore.MigrationExtensions.Generation.Contracts;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace EFCore.MigrationExtensions.Generation;

internal abstract class CustomMigrationOperationGeneratorBase<T> : ICustomMigrationOperationGenerator
    where T : CustomMigrationOperation
{
    public Type OperationType => typeof(T);

    public void Generate(CustomMigrationOperation operation, IndentedStringBuilder builder)
    {
        if (operation is T typedOperation)
        {
            Generate(typedOperation, builder);
            return;
        }

        throw new InvalidOperationException(
            $"Ожидался тип операции {typeof(T).Name}, но получен {operation.GetType()}");
    }

    protected abstract void Generate(T operation, IndentedStringBuilder builder);
}