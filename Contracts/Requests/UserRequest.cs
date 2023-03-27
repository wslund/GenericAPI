using System;
using System.Collections.Generic;

namespace GenericAPI.Contracts.Requests
{
    public class UserRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime Age { get; set; }
        public Guid CompanyId { get; set; }

        public List<Guid> RoleIds { get; set; }
    }
}
