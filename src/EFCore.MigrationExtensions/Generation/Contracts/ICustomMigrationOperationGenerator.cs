using System;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace EFCore.MigrationExtensions.Generation.Contracts;

internal interface ICustomMigrationOperationGenerator
{
    Type OperationType { get; }

    void Generate(CustomMigrationOperation operation, IndentedStringBuilder builder);
}