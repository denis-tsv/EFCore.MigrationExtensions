using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using EFCore.MigrationExtensions.Utils;
using EFCore.MigrationExtensions.Generation.Contracts;
using EFCore.MigrationExtensions.SqlObjects;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Internal;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Update;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace EFCore.MigrationExtensions.Generation;

/// <summary> Calculates the difference between source and target models </summary>
[SuppressMessage("Usage", "EF1001:Internal EF Core API usage.")]
public sealed class CustomMigrationsModelDiffer : MigrationsModelDiffer
{
    private readonly IReadOnlyCollection<IModelDiffer> _differs;

    /// <summary> Calculates the difference between source and target models </summary>
    public CustomMigrationsModelDiffer(
        IRelationalTypeMappingSource typeMappingSource,
        IMigrationsAnnotationProvider migrationsAnnotations,
        IChangeDetector changeDetector,
        IUpdateAdapterFactory updateAdapterFactory,
        CommandBatchPreparerDependencies commandBatchPreparerDependencies,
        IEnumerable<IModelDiffer> differs) : base(
        typeMappingSource,
        migrationsAnnotations,
        changeDetector,
        updateAdapterFactory,
        commandBatchPreparerDependencies)
    {
        _differs = differs.ToList();
    }

    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    protected override IReadOnlyList<MigrationOperation> Sort(IEnumerable<MigrationOperation> operations,
        DiffContext diffContext)
    {
        operations.DivideByType<MigrationOperation, CreateOrUpdateSqlObjectOperation, DropSqlObjectOperation>(out var sqlOps, out var dropOps, out var otherOperations);

        return dropOps.OrderSqlObjects() // drop objects
            .Concat(base.Sort(otherOperations, diffContext)) // drop / create tables, etc.
            .Concat(sqlOps.OrderSqlObjects()) // create or update objects
            .ToList();
    }

    /// <summary> Compare the models and create operations corresponding to the difference between the models. </summary>
    protected override IEnumerable<MigrationOperation> Diff(IRelationalModel? source, IRelationalModel? target,
        DiffContext diffContext)
    {
        return base.Diff(source, target, diffContext)
            .Concat(_differs.SelectMany(d => d.GetDiff(source, target)));
    }
}