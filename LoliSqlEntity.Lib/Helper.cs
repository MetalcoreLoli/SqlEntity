using System;
using System.Collections.Generic;
using System.Linq;

namespace LoliSqlEntity.Lib
{
    internal static class Helper
    {
        public static string ToCharsString(this IEnumerable<Char> source)
            => source.Aggregate("", (acc, c) => acc + c);

        public static string AsStringWithDelimiter<T>(this IEnumerable<T> source, string delimiter) => 
            source.Aggregate("", (acc, elem) => acc + elem + delimiter).SkipLast(delimiter.Length).ToCharsString();

        public static string AsStringWithDelimiter<T, TOut>(this IEnumerable<T> source, string delimiter,
            Func<T, TOut> factory)
            => (from n in source select factory(n)).AsStringWithDelimiter(delimiter);
    }
}