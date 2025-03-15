using System.Collections.Generic;
using System.Linq;
using EFCore.MigrationExtensions.SqlObjects;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace EFCore.MigrationExtensions.Generation;

/// <summary> Extensions necessary for code generation </summary>
public static class GenerationExtensions
{
    /// <summary> Filters annotations </summary>
    public static IEnumerable<IAnnotation> FilterCustomIgnoredAnnotations(this IEnumerable<IAnnotation> annotations)
    {
        return annotations
            .Where(a => a.Name != SqlObjectsModelExtensions.SqlObjectsData);
    }
}