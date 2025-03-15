using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace EFCore.MigrationExtensions.Utils;

internal static class EnumerableExtensions
{
    public static IEnumerable<T> WhereNotNull<T>(this IEnumerable<T?> value)
    {
        return value.Where(v => v is not null).Cast<T>();
    }

    /// <summary> Divides the initial sequence into 3 groups of elements depending on their class </summary>
    public static void DivideByType<TSrc, T1, T2>(
        this IEnumerable<TSrc> source,
        out IReadOnlyCollection<T1> first,
        out IReadOnlyCollection<T2> second,
        out IReadOnlyCollection<TSrc> other)
        where T1 : TSrc
        where T2 : TSrc
        where TSrc : class
    {
        var result = source.DivideByType(new[] { typeof(T1), typeof(T2) });
        first = (IReadOnlyCollection<T1>)result[0];
        second = (IReadOnlyCollection<T2>)result[1];
        other = (IReadOnlyCollection<TSrc>)result[2];
    }

    /// <summary> Divides the initial sequence into groups of elements depending on their class </summary>
    public static IReadOnlyList<IList> DivideByType<TSrc>(
        this IEnumerable<TSrc> source, IReadOnlyCollection<Type> types)
        where TSrc : class
    {
        var typesWithSrc = types.Concat(new[] { typeof(TSrc) }).ToArray();
        var result = typesWithSrc
            .Select(t => (IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(t))!)
            .ToArray();

        foreach (var element in source)
        {
            for (var i = 0; i < typesWithSrc.Length; i++)
            {
                if (typesWithSrc[i].IsInstanceOfType(element))
                {
                    result[i].Add(element);
                    break;
                }
            }
        }

        return result;
    }

    /// <summary>Converts the list to a comma-separated string.</summary>
    public static string JoinBySeparator<T>(this IEnumerable<T> value, string separator)
    {
        return string.Join(separator, value.Select(val => val?.ToString()));
    }
}