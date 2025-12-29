using Microsoft.AspNetCore.Mvc;
using TurnApi.DTOs.Request;
using TurnApi.Services.Interfaces;

namespace TurnApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService accountService;

        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        [HttpPost]
        public void CreateAccount([FromBody] AccountCreationRequest accountRequest)
        {
            accountService.VerifyAccountAlreadyExist(accountRequest);
        }


    }
}
