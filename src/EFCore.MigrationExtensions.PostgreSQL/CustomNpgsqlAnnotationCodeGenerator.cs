namespace EFCore.MigrationExtensions.PostgreSQL;

using System.Collections.Generic;
using EFCore.MigrationExtensions.Generation;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Npgsql.EntityFrameworkCore.PostgreSQL.Design.Internal;

#pragma warning disable EF1001 // Internal EF Core API usage.
/// <summary> Extensions for using SQL objects. </summary>
internal class CustomNpgsqlAnnotationCodeGenerator : NpgsqlAnnotationCodeGenerator
{
    public CustomNpgsqlAnnotationCodeGenerator(AnnotationCodeGeneratorDependencies dependencies) : base(dependencies)
    {
    }
#pragma warning restore EF1001 // Internal EF Core API usage.

    /// <inheritdoc />
    public override IEnumerable<IAnnotation> FilterIgnoredAnnotations(IEnumerable<IAnnotation> annotations)
    {
        return base.FilterIgnoredAnnotations(annotations).FilterCustomIgnoredAnnotations();
    }
}