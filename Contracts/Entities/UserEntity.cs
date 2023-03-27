using GenericAPI.Contexts;
using GenericAPI.Contracts.Entities.Iinterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GenericAPI.Contracts.Entities
{
    public class UserEntity : IEntity
    {

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime Created { get; set; }
        public DateTime Update { get; set; }



        [ForeignKey(nameof(CompanyId))]
        public Guid CompanyId { get; set; }

        public CompanyEntity Company { get; set; }


        public List<UserRoleEntity> UserRoles { get; set; }
        
    }

}
