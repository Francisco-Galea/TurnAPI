using TurnApi.DTOs.Request;
using TurnApi.Models;

namespace TurnApi.Repositories.Interface
{
    public interface IAccountRepository
    {
        void CreateAccount(AccountCreationRequest accountRequest);
        void AccountAlreadyExist(int document);
        void CreateTurn(Turn turn);
    }
}
