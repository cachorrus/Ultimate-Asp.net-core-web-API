using MediatR;
using Shared.DataTransferObjects;

namespace Application.Commands
{
    public sealed record UpdateCompanyCommand(Guid Id, CompanyForUpdateDto Company, bool TrackChanges) : IRequest;
}
