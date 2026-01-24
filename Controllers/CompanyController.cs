using Microsoft.AspNetCore.Mvc;
using TurnApi.DTOs.Request;
using TurnApi.DTOs.Response;
using TurnApi.Models;
using TurnApi.Services.Interfaces;

namespace TurnApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {

        private readonly ICompanyService companyService;

        public CompanyController(ICompanyService companyService)
        {
            this.companyService = companyService;
        }

        [HttpPost("/CreateCompany")]
        public void CreateCompany([FromBody] CreateCompanyRequest createCompanyRequest)
        {
            companyService.VerifyCompanyAlreadyExist(createCompanyRequest);
        }

        [HttpPost("/FireEmployee")]
        public void FireEmployee(int companyId, int accountId)
        {
            companyService.FireEmployee(companyId, accountId);
        }

        [HttpPost("/HireEmployee")]
        public void HireEmployee([FromBody] HireOrFireEmployeeRequest hireOrFireEmployeeRequest)
        {
            companyService.HireEmployee(hireOrFireEmployeeRequest);
        }

        [HttpGet("/GetAllEmployees")]
        public List<EmployeeResponse> GetAllEmployees(int companyId)
        {
            return companyService.GetAllEmployees(companyId);    
        }

    }
}
