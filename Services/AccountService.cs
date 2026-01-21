using TurnApi.DTOs.Request;
using TurnApi.DTOs.Response;
using TurnApi.Models;
using TurnApi.Repositories.Interface;
using TurnApi.Services.Interfaces;
using TurnApi.Utils;

namespace TurnApi.Services
{
    internal sealed class AccountService : IAccountService
    {

        private readonly IAccountRepository accountRepository;
        private readonly IAgendaService agendaService;

        public AccountService(IAccountRepository accountRepository, IAgendaService agendaService)
        {
            this.accountRepository = accountRepository;
            this.agendaService = agendaService;
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

        public void CreateTurn(CreateTurnRequest createTurnRequest)
        {
            AgendaResponse agendaResponse = agendaService.IsTurnAvailable(createTurnRequest);
            
            Turn turn = new()
            {
                agendaId = createTurnRequest.agendaId,
                accountClientId = createTurnRequest.accountClientId,
                turnDate = createTurnRequest.turnDate,
                turnInit = createTurnRequest.turnInit,
                turnEnd = createTurnRequest.turnInit.AddMinutes(agendaResponse.turnDurationInMinutes),
                notes = createTurnRequest.notes,
            };
            accountRepository.CreateTurn(turn);
        }

    }
}
