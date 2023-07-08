using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_Labs2
{
    static class IEnumrable
    {
        public static IEnumerable<IEnumerable<T>> GenerateCombinations<T>(
            this IEnumerable<T> list,
            int count,
            IEqualityComparer<T> comparer)
        {
            if (list.Count() != list.Distinct(comparer).Count())
            {
                throw new ArgumentException(
                    "Equall values are present here",
                    nameof(list));
            }

            if (count == 1) return list.Select(T => new T[] { T });

            return GenerateCombinations(list, count - 1, comparer)
                 .SelectMany(t => list, (T1, T2) => T1.Concat(new T[] { T2 }));

        }

        public static IEnumerable<IEnumerable<T>> GenerateSubsets<T>(
            this IEnumerable<T> list,
            IEqualityComparer<T> comparer)
        {
            if (list.Count() != list.Distinct(comparer).Count())
            {
                throw new ArgumentException(
                    "Equall values are present here",
                    nameof(list));
            }

            var listArray = list as T[] ?? list.ToArray();

            for (int i = 0; i < (1 << listArray.Length); i++)
            {
                var res = Array.Empty<T>();

                var mask = i;

                foreach (var item in listArray) 
                {
                    if ((mask & 1) == 1)
                    {
                        res = res.Concat(new[] { item }).ToArray();
                    }
                    mask >>= 1;
                }

                yield return res;
            }
        }

        public static IEnumerable<IEnumerable<T>> GenerateReshuffles<T>(
            this IEnumerable<T> list,
            IEqualityComparer<T> comparer)
        {
            if (list.Count() != list.Distinct(comparer).Count())
            {
                throw new ArgumentException(
                    "Equall values are present here",
                    nameof(list));
            }

            if (!list.Any())
            {
                yield return Enumerable.Empty<T>();
                yield break;
            }

            var ind = 0;
            foreach (var item in list) 
            {
                var restOf = list.Take(ind).Concat(list.Skip(ind + 1));

                foreach (var item2 in restOf.GenerateReshuffles(comparer))
                {
                    yield return new[] { item }.Concat(item2);
                }
                ind++;
            }
        }
    }
}
