using System;
using System.Linq;

namespace UpcomingMoviesBackend.Data.Local
{
    public static class IQueryableExtensions
    {
        /// <summary>
        /// Performs paging on IQueryable object
        /// </summary>
        public static PagedResult<T> GetPaged<T>(this IQueryable<T> query,
                                         int page, int pageSize) where T : class
        {
            var result = new PagedResult<T>();
            result.Page = page;
            result.PageSize = pageSize;
            result.TotalResults = query.Count();

            var pageCount = (double)result.TotalResults / pageSize;
            result.TotalPages = (int)Math.Ceiling(pageCount);

            var skip = (page - 1) * pageSize;
            result.Results = query.Skip(skip).Take(pageSize).ToList();

            return result;
        }
    }
}
