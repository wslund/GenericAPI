using AutoMapper;
using GenericAPI.Contracts.Entities;
using GenericAPI.Contracts.Models;
using GenericAPI.Contracts.Requests;

namespace GenericAPI.Profiles
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            CreateMap<CompanyRequest, CompanyEntity>();
            CreateMap<CompanyEntity, CompanyModel>().ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.Discription,
                 opt => opt.MapFrom(s => s.Discription));
        }
    }
}
