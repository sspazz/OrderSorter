using Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Helper
{
    public static class IQueryableExtensions
    {
        public static IQueryable<TEntityModel> IncludeMultiple<TEntityModel>(this IQueryable<TEntityModel> query, IEnumerable<Expression<Func<TEntityModel, object>>> includes)
        where TEntityModel : BaseEntityModel
            {
                if (includes != null)
                {
                    return includes.Aggregate(query, (current, include) => current.Include(include));
                }

                return query;
            }
    }
}
