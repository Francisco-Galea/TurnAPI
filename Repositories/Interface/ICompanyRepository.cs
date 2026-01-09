using TurnApi.DTOs.Request;

namespace TurnApi.Repositories.Interface
{
    public interface ICompanyRepository
    {
        void CreateCompanyRequest(CreateCompanyRequest createCompanyRequest);
        void VerifyCompanyAlreadyExist(string socialReason);
    }
}
