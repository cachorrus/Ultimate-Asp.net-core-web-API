using Application.Commands;
using Application.Notifications;
using Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.DataTransferObjects;

namespace CompanyEmployees.Presentation.Controllers
{
    [Route("api/companies")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly IPublisher _publisher;

        public CompaniesController(ISender sender, IPublisher publisher)
        {
            _sender = sender;
            _publisher = publisher;
        }

        [HttpGet]
        public async Task<IActionResult> GetCompanies()
        {
            var companies = await _sender.Send(new GetCompaniesQuery(TrackChanges: false));
            
            return Ok(companies);
        }

        [HttpGet("{id:guid}", Name = "CompanyById")]
        public async Task<IActionResult> GetCompany(Guid id)
        {
            var company = await _sender.Send(new GetCompanyQuery(id, TrackChanges: false));
            
            return Ok(company);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompany([FromBody] CompanyForCreationDto companyForCreationDto)
        {
            //Validacion realziada en CreateCompanyCommandValidator pero regresara el estatus 422
            //se recomienda que cuando el objeto es null se retorne el estatus 400 como a continuacion
            //if (companyForCreationDto is null)
            //    return BadRequest("CompanyForCreationDto object is null");

            var company = await _sender.Send(new CreateCompanyCommand(companyForCreationDto));
            
            return CreatedAtRoute("CompanyById", new { id = company.Id }, company);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateCompany(Guid id, CompanyForUpdateDto companyForUpdateDto)
        {
            if (companyForUpdateDto is null)
                return BadRequest("CompanyForUpdateDto object is null");

            await _sender.Send(new UpdateCompanyCommand(id, companyForUpdateDto, TrackChanges: true));
            
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteCompany(Guid id)
        {
            await _publisher.Publish(new CompanyDeletedNotification(id, TrackChanges: false));

            return NoContent();
        }
    }
}
