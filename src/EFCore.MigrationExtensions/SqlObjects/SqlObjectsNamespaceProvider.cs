using System;
using System.Collections.Generic;
using System.Linq;
using EFCore.MigrationExtensions.Generation.Contracts;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EFCore.MigrationExtensions.SqlObjects;

internal class SqlObjectsNamespaceProvider : IModelNamespaceProvider
{
    public IEnumerable<string?> GetNamespaces(IModel model)
    {
        if (model.GetSqlObjects().Any())
        {
            yield return typeof(SqlObjectsModelExtensions).Namespace;
        }
    }
}