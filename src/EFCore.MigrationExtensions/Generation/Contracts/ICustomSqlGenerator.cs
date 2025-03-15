using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.MigrationExtensions.Generation.Contracts;

/// <summary> SQL-generator </summary>
public interface ICustomSqlGenerator
{
    /// <summary> Operation type </summary>
    Type OperationType { get; }

    /// <summary> Generate code </summary>
    void Generate(CustomMigrationOperation operation, MigrationCommandListBuilder builder);
}