using TurnApi.DTOs.Request;

namespace TurnApi.Repositories.Interface
{
    public interface IAccountRepository
    {
        void CreateAccount(AccountCreationRequest accountRequest);
        void AccountAlreadyExist(string document);
    }
}
