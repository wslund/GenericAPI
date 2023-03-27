using GenericAPI.Contracts.Entities;
using System.Data.Entity;
using System.Linq;

namespace GenericAPI.Contracts.Query
{
    public class RoleQuery : PaigeListQuery<RoleEntity, RoleQuery>
    {
        public string? Role { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public override IQueryable<RoleEntity?> AddFilter(IQueryable<RoleEntity> quaryable, RoleQuery query)
        {
            if (query == null)
                return quaryable;

            if (!string.IsNullOrEmpty(query.Role))
                quaryable = quaryable.Where(x => x.Role.ToUpper()
                .Contains(query.Role.ToUpper()));

            return quaryable.Include(x => x.Company).AsQueryable();
        }

        
    }
}
