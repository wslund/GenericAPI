using GenericAPI.Contracts.Entities;
using System;
using System.Linq;

namespace GenericAPI.Contracts.Query
{
    public class UserRoleQuery : PaigeListQuery<UserRoleEntity, UserRoleQuery>
    {
        public Guid? UserId { get; set; }
        public Guid? RoleId { get; set; }

        public override IQueryable<UserRoleEntity?> AddFilter(IQueryable<UserRoleEntity> quaryable, UserRoleQuery query)
        {
            return quaryable;
        }

        //public override IQueryable<UserRoleEntity?> Including(IQueryable<UserRoleEntity> quaryable)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
