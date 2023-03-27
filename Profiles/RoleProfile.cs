using AutoMapper;
using GenericAPI.Contracts.Entities;
using GenericAPI.Contracts.Models;
using GenericAPI.Contracts.Requests;

namespace GenericAPI.Profiles
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<RoleRequest, RoleEntity>();

            CreateMap<RoleEntity, RoleModel>().ForMember(d => d.Role, 
                opt => opt.MapFrom(s => 
                $"{s.Role}")).ForMember(x => x.Company, opt => opt.MapFrom(s => s.Company));
        }
    }
}
