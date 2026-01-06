using TurnApi.DTOs.Request;

namespace TurnApi.Services.Interfaces
{
    public interface ICompanyService
    {
        void CreateCompany(CreateCompanyRequest createCompanyRequest);
    }
}
