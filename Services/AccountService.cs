using TurnApi.DTOs.Request;
using TurnApi.Repositories.Interface;
using TurnApi.Services.Interfaces;

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
            try
            {
                accountRepository.CreateAccount(accountRequest);
            }
            catch
            {

            }
            finally
            {

            }
        }



    }
}
