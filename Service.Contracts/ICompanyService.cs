using Entities.Responses;

namespace Service.Contracts
{
    public interface ICompanyService
    {
        ApiBaseResponse GetAllCompanies(bool trackChanges);
        ApiBaseResponse GetCompany(Guid companyId, bool trackChanges);
    }
}
