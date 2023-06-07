using CompanyEmployees.Presentation.Extensions;
using Entities.Responses;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace CompanyEmployees.Presentation.Controllers
{
    [Route("api/companies")]
    [ApiController]
    public class CompaniesController : ApiControllerBase
    {
        private readonly IServiceManager _service;
        public CompaniesController(IServiceManager service) => _service = service;
        
        [HttpGet]
        public IActionResult GetCompanies()
        {
            var baseResult = _service.CompanyService.GetAllCompanies(trackChanges: false);

            var companies = baseResult.GetResult<IEnumerable<CompanyDto>>();

            return Ok(companies);
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetCompany(Guid id)
        {
            var baseResult = _service.CompanyService.GetCompany(id, trackChanges: false);

            if (!baseResult.Success)
                return ProcessError(baseResult);

            var company = baseResult.GetResult<CompanyDto>();

            return Ok(company);
        }
    }
}
