using TurnApi.DTOs.Request;
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

    }
}
