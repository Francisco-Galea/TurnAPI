using TurnApi.DTOs.Request;
using TurnApi.DTOs.Response;
using TurnApi.Models;
using TurnApi.Repositories.Interface;
using TurnApi.Services.Interfaces;

namespace TurnApi.Services
{
    public class CompanyService : ICompanyService
    {

        private ICompanyRepository companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            this.companyRepository = companyRepository;
        }

        public void CreateCompany(CreateCompanyRequest createCompanyRequest)
        {
            Company company = new Company()
            {
                companyName = createCompanyRequest.companyName,
                accountId = createCompanyRequest.founderAccountId,
                socialReason = createCompanyRequest.socialReason,
                cuit = createCompanyRequest.cuit
            };
            companyRepository.CreateCompanyRequest(createCompanyRequest);
        }

        public void FireEmployee(int companyId, int accountId)
        {
            companyRepository.FireEmployee(companyId, accountId);
        }

        public List<EmployeeResponse> GetAllEmployees(int companyId)
        {
            return companyRepository.GetAllHiredEmployees(companyId);
        }

        public void HireEmployee(int companyId, int accountId)
        {
            companyRepository.HireEmployee(companyId, accountId);
        }

        public void VerifyCompanyAlreadyExist(CreateCompanyRequest createCompanyRequest)
        {
            companyRepository.VerifyCompanyAlreadyExist(createCompanyRequest.socialReason);
            CreateCompany(createCompanyRequest);
        }

    }
}
