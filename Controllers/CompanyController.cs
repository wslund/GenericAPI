using GenericAPI.Contracts.Entities;
using GenericAPI.Contracts.Models;
using GenericAPI.Contracts.Query;
using GenericAPI.Contracts.Requests;
using GenericAPI.Repository.Interfaces;
using GenericAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GenericAPI.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IGenericService<CompanyModel, CompanyQuery, CompanyEntity, CompanyRequest> _genericService;
        
        public CompanyController(IGenericService<CompanyModel, CompanyQuery, CompanyEntity, CompanyRequest> genericService)
        {
            _genericService = genericService;
        }

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> GetById(Guid id)
        {
            var company = await _genericService.GetById(id);
            if (company == null)
                return NotFound("Failed to get company");

            return Ok(company);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CompanyRequest companyRequest)
        {
            var company = await _genericService.Create(companyRequest);
            if (company == null)
            {
                return NotFound("Failed to create company");
            }
            return Ok(company);
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] CompanyQuery query)
        {
            var company = await _genericService.Get(query);
            if (company == null)
            {
                return NotFound("Failed to get company");
            }
            return Ok(company);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, CompanyRequest companyRequest)
        {
            var result = await _genericService.Update(id, companyRequest);
            if (result == null)
            {
                return NotFound("Failed to update company");
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var company = await _genericService.Delete(id);
            if (company == null)
            {
                return NotFound("Failed to delete company");
            }
            return Ok(company);
        }


    }
}
