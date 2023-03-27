using GenericAPI.Contracts.Entities.Iinterfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GenericAPI.Contracts.Entities
{
    public class RoleEntity : IEntity
    {
        public Guid Id { get; set; }
        public string Role { get; set; }
        public DateTime Created { get; set; }
        public DateTime Update { get; set; }


        [ForeignKey(nameof(CompanyId))]
        public Guid CompanyId { get; set; }
        public CompanyEntity Company { get; set; }


        public List<UserRoleEntity> UserRoles { get; set; }
    }
}
