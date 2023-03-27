using AutoMapper;
using GenericAPI.Contracts.Entities;
using GenericAPI.Contracts.Models;
using GenericAPI.Contracts.Requests;
using System;
using System.Linq;

namespace GenericAPI.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserRequest, UserEntity>();

        CreateMap<UserEntity, UserModel>().ForMember(d => d.Name,
            opt => opt.MapFrom(s =>
                $"{s.FirstName}, {s.LastName}"))
            .ForMember(d => d.Age,
            opt => opt.MapFrom(s => CalculateAge(s.DateOfBirth)))
            .ForMember(x => x.Roles, opt => opt.MapFrom(c => c.UserRoles.Select(r => r.Role)));


    }


    private static int CalculateAge(DateTime birthDate)
    {
        var dtn = DateTime.Now;
        int age = dtn.Year - birthDate.Year;
        if (dtn.Month < birthDate.Month || (dtn.Month == birthDate.Month && dtn.Day < birthDate.Day))
            age--;
        return age;
    }

}

