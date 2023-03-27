using GenericAPI.Contracts.Entities;
using GenericAPI.Helper;
using GenericAPI.Helper.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GenericAPI.Contracts.Query
{
    public class UserQuery : PaigeListQuery<UserEntity, UserQuery>
    {
        private readonly ISortHelper<UserEntity> _sortHelper;

        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        //public UserQuery()
        //{
        //    _sortHelper = new SortHelper<UserEntity>();
        //}

        public UserQuery(ISortHelper<UserEntity> sortHelper)
        {
            _sortHelper = sortHelper;
        }

        public override IQueryable<UserEntity?> AddFilter(IQueryable<UserEntity?> quaryable, UserQuery? query)
        {
            
            if(query == null)
                return quaryable;

            if (!string.IsNullOrEmpty(query.FirstName))
                quaryable = quaryable.Where(x => x.FirstName.ToUpper()
                .Contains(query.FirstName.ToUpper()));
            

            if (!string.IsNullOrEmpty(query.LastName))
                quaryable = quaryable.Where(x => x.LastName.ToUpper()
                .Contains(query.LastName.ToUpper()));

            if (!string.IsNullOrEmpty(query.OrderBy))
                quaryable = _sortHelper.ApplySort(quaryable, query.OrderBy);





            return quaryable.Include(x => x.Company).Include(x => x.UserRoles).ThenInclude(x => x.Role);
        }
     
    }
}

