using MediatR;
using Shared.DataTransferObjects;

namespace Application.Queries
{
    public sealed record GetCompaniesQuery(bool TrackChanges) : IRequest<IEnumerable<CompanyDto>>;
}
