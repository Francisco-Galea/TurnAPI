using TurnApi.DTOs.Request;
using TurnApi.Models;

namespace TurnApi.Services.Interfaces
{
    public interface ICompanyService
    {
        void CreateCompany(CreateCompanyRequest createCompanyRequest);
        void VerifyCompanyAlreadyExist(CreateCompanyRequest createCompanyRequest);
        void HireEmployee(int companyId, int accountId);
        void FireEmployee(int companyId, int accountId);
        List<Account> GetAllEmployees(int companyId);
    }
}
