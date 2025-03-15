using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EFCore.MigrationExtensions.Generation.Contracts;

internal interface ICustomSnapshotGenerator
{
    void Generate(string builderName, IModel model, IndentedStringBuilder stringBuilder);
}