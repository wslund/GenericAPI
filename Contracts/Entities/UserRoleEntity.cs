using GenericAPI.Contracts.Entities.Iinterfaces;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GenericAPI.Contracts.Entities
{
    public class UserRoleEntity : IEntity
    {
        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Update { get; set; }


        public Guid UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public UserEntity User { get; set; }

        public Guid RoleId { get; set; }
        [ForeignKey(nameof(RoleId))]
        public RoleEntity Role { get; set; }
    }
}
