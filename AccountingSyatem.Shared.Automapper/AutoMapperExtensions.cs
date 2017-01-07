using System.Collections.Generic;
using System.Linq;
using AutoMapper;

namespace AccountingSyatem.Shared.Automapper
{
    public static class AutoMapperExtensions
    {
        public static TU MapTo<T, TU>(this T from, TU toEntity)
        {
            Mapper.Map(from, toEntity);
            return toEntity;
        }

        public static IEnumerable<TU> Select<T, TU>(this IEnumerable<T> from, TU obj)
            where TU : new()
        {
            return from.Select(n => MapTo<T, TU>(n, new TU()));
        }
    }
}