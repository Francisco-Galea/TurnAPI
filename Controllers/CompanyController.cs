using Microsoft.AspNetCore.Mvc;
using TurnApi.DTOs.Request;
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

        [HttpPost]
        public void CreateCompany([FromBody] CreateCompanyRequest createCompanyRequest)
        {
            companyService.VerifyCompanyAlreadyExist(createCompanyRequest);
        }

    }
}
