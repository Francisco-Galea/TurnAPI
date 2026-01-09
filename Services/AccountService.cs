using TurnApi.DTOs.Request;
using TurnApi.Repositories.Interface;
using TurnApi.Services.Interfaces;
using TurnApi.Utils;

namespace TurnApi.Services
{
    internal sealed class AccountService : IAccountService
    {

        private readonly IAccountRepository accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }
        

        public void CreateAccount(AccountCreationRequest accountRequest)
        {
            accountRequest.password = PasswordUtil.HashPassword(accountRequest.password);   
            accountRepository.CreateAccount(accountRequest);
        }

        public void VerifyAccountAlreadyExist(AccountCreationRequest accountRequest)
        {
            accountRepository.AccountAlreadyExist(accountRequest.document);
            CreateAccount(accountRequest);
        }

    }
}
