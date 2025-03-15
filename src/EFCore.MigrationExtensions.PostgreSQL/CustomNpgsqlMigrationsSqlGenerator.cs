using System;
using System.Collections.Generic;
using System.Linq;
using EFCore.MigrationExtensions.Generation;
using EFCore.MigrationExtensions.Generation.Contracts;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure.Internal;
using Npgsql.EntityFrameworkCore.PostgreSQL.Migrations;

namespace EFCore.MigrationExtensions.PostgreSQL;

/// <summary> Sql generator </summary>
public sealed class CustomNpgsqlMigrationsSqlGenerator : NpgsqlMigrationsSqlGenerator
{
    private readonly IReadOnlyDictionary<Type, ICustomSqlGenerator> _generators;

#pragma warning disable EF1001 // Internal EF Core API usage.
    /// <summary> Sql generator </summary>
    public CustomNpgsqlMigrationsSqlGenerator(MigrationsSqlGeneratorDependencies dependencies, INpgsqlSingletonOptions npgsqlOptions,
        IEnumerable<ICustomSqlGenerator> sqlGenerators) : base(
        dependencies, npgsqlOptions)
#pragma warning restore EF1001 // Internal EF Core API usage.
    {
        _generators = sqlGenerators.ToDictionary(g => g.OperationType);
    }

    /// <inheritdoc />
    protected override void Generate(
        MigrationOperation operation,
        IModel? model,
        MigrationCommandListBuilder builder)
    {
        if (operation is CustomMigrationOperation customOp && _generators.ContainsKey(operation.GetType()))
        {
            _generators[operation.GetType()].Generate(customOp, builder);
            return;
        }

        base.Generate(operation, model, builder);
    }
}