using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace EFCore.MigrationExtensions.Generation.Contracts;

/// <summary> Find the difference between models </summary>
public interface IModelDiffer
{
    /// <summary> Find the difference between models </summary>
    IReadOnlyCollection<MigrationOperation> GetDiff(IRelationalModel? source, IRelationalModel? target);
}