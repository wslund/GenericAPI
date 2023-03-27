using GenericAPI.Contracts.Entities.Iinterfaces;
using System;
using System.Collections.Generic;

namespace GenericAPI.Contracts.Entities
{
    public class CompanyEntity : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Discription { get; set; }
        public DateTime Update { get; set; }
        public DateTime Created { get; set; }

        public ICollection<UserEntity> Users { get; set; }
        public ICollection<RoleEntity> Roles { get; set; }
    }
}
