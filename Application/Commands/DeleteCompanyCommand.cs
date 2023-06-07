using MediatR;

namespace Application.Commands
{
    public record DeleteCompanyCommand(Guid Id, bool TrackChanges) : IRequest;
}
