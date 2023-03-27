using System;
using System.Linq;

namespace GenericAPI.Contracts.Query
{
    public abstract class PaigeListQuery<TEntity, TQuery>
    {
        public int PageSize { get; set; } = 10;
        public int PageNumber { get; set; } = 1;
        public string OrderBy { get; set; }

        public abstract IQueryable<TEntity?> AddFilter(IQueryable<TEntity> quaryable, TQuery query);   
    }
}

