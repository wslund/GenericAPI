using GenericAPI.Contracts.Entities;
using GenericAPI.Contracts.Models;
using GenericAPI.Contracts.Query;
using GenericAPI.Contracts.Requests;
using GenericAPI.Services;
using GenericAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GenericAPI.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IGenericService<UserModel, UserQuery, UserEntity, UserRequest> _userService;


        public UserController(IGenericService<UserModel, UserQuery, UserEntity, UserRequest> userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> GetById(Guid id)
        {
            var user = await _userService.GetById(id);
            if (user == null)
                return NotFound("Failed to get user");

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserRequest userRequest)
        {
            var user = await _userService.Create(userRequest);
            if (user == null)
            {
                return NotFound("Failed to create user");
            }
            return Ok(user);
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] UserQuery query)
        {
            var user = await _userService.Get(query);
            if (user == null)
            {
                return NotFound("Failed to get user");
            }
            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, UserRequest userRequest)
        {
            var result = await _userService.Update(id, userRequest);
            if (result == null)
            {
                return NotFound("Failed to update user");
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var user = await _userService.Delete(id);
            if (user == null)
            {
                return NotFound("Failed to delete user");
            }
            return Ok(user);
        }
    }
}
