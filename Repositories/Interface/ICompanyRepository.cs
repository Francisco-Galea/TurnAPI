using TurnApi.DTOs.Request;
using TurnApi.DTOs.Response;
using TurnApi.Models;

namespace TurnApi.Repositories.Interface
{
    public interface ICompanyRepository
    {
        void CreateCompanyRequest(CreateCompanyRequest createCompanyRequest);
        void VerifyCompanyAlreadyExist(string socialReason);
        void HireEmployee(int companyId, int accountId);
        void FireEmployee(int companyId, int accountId);
        List<EmployeeResponse> GetAllHiredEmployees(int companyId);   
    }
}
