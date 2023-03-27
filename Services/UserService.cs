using AutoMapper;
using GenericAPI.Contexts;
using GenericAPI.Contracts.Entities;
using GenericAPI.Contracts.Models;
using GenericAPI.Contracts.Query;
using GenericAPI.Contracts.Requests;
using GenericAPI.Repository.Interfaces;
using GenericAPI.Services.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GenericAPI.Services
{
    public class UserService : GenericService<UserModel, UserQuery, UserEntity, UserRequest>
    {
        
        private DataContext _context;
        private readonly IMapper _mapper;
        private readonly IGenericRepository<UserRoleEntity, UserRoleQuery> _userRoleRepository;
        
        
        private readonly IGenericRepository<UserEntity, UserQuery> _userRepository;
        public UserService(
            DataContext context,
            IMapper mapper, 
            IGenericRepository<UserEntity, UserQuery> userRepository, 
            IGenericRepository<UserRoleEntity, UserRoleQuery> userRoleRepository) 
            : base(mapper, userRepository)
        {
            _context = context;
            _mapper = mapper;
            _userRepository = userRepository;
            _userRoleRepository = userRoleRepository;
        }

        public async override Task<UserModel> Create(UserRequest request)
        {
            var user = await base.Create(request);

            ArgumentNullException.ThrowIfNull(user);

            var userRoles = request.RoleIds.Select(x => new UserRoleEntity
            {
                UserId = user.Id,
                RoleId = x
            }).ToList();

            var result = await _userRoleRepository.Create(userRoles);

            return user;
        }
    }
}
