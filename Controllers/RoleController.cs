

using GenericAPI.Contracts.Entities;
using GenericAPI.Contracts.Models;
using GenericAPI.Contracts.Query;
using GenericAPI.Contracts.Requests;
using GenericAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GenericAPI.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IGenericService<RoleModel, RoleQuery, RoleEntity, RoleRequest> _genericService;

        public RoleController(IGenericService<RoleModel, RoleQuery, RoleEntity, RoleRequest> genericService)
        {
            _genericService = genericService;
        }

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> GetById(Guid id)
        {
            var role = await _genericService.GetById(id);
            if (role == null)
                return NotFound("Failed to get role");
            
            return Ok(role);
        }

        [HttpPost]
        public async Task<IActionResult> Create(RoleRequest RoleRequest)
        {
            var role = await _genericService.Create(RoleRequest);
            if (role == null)
            {
                return NotFound("Failed to create role");
            }
            return Ok(role);
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] RoleQuery query)
        {
            var role = await _genericService.Get(query);
            if (role == null)
            {
                return NotFound("Failed to get role");
            }
            return Ok(role);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, RoleRequest roleRequest)
        {
            var result = await _genericService.Update(id, roleRequest);
            if (result == null)
            {
                return NotFound("Failed to update role");
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var role = await _genericService.Delete(id);
            if (role == null)
            {
                return NotFound("Failed to delete role");
            }
            return Ok(role);
        }

    }
}
