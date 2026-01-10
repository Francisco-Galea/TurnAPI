using TurnApi.DTOs.Request;
using TurnApi.Models;

namespace TurnApi.Repositories.Interface
{
    public interface ICompanyRepository
    {
        void CreateCompanyRequest(CreateCompanyRequest createCompanyRequest);
        void VerifyCompanyAlreadyExist(string socialReason);
        void HireEmployee(int companyId, int accountId);
        void FireEmployee(int companyId, int accountId);
        List<Account> GetAllEmployees(int companyId);   
    }
}
