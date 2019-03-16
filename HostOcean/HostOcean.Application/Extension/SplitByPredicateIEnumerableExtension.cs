using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HostOcean.Application.Extension
{
    public static class SplitByPredicateIEnumerableExtension
    {
        public static async Task<(IEnumerable<TEntity> Match, IEnumerable<TEntity> NoMatch)> 
            SplitByPredicateAsync<TEntity>(
                    this IEnumerable<TEntity> source,
                    Func<TEntity, Task<bool>> predicate
                ) where TEntity : class
        {
            var match = new List<TEntity>();
            var noMatch = new List<TEntity>();

            foreach (var entity in source)
            {
                if (await predicate(entity))
                {
                    match.Add(entity);
                }
                else
                {
                    noMatch.Add(entity);
                }
            }

            return (match, noMatch);
        }
    }
}