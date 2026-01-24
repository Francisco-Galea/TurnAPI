using TurnApi.DTOs.Request;
using TurnApi.DTOs.Response;
using TurnApi.Models;
using TurnApi.Models.Enums;
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

        public void CreateAppointment(CreateAppointmentRequest createTurnRequest)
        {
            AgendaResponse agendaResponse = agendaService.IsAppointmentAvailable(createTurnRequest);
            
            Appointment appointment = new()
            {
                agendaId = createTurnRequest.agendaId,
                accountClientId = createTurnRequest.accountClientId,
                appointmentDate = createTurnRequest.appointmentDate,
                appointmentInit = createTurnRequest.appointmentInit,
                appointmentEnd = createTurnRequest.appointmentInit.AddMinutes(agendaResponse.appointmentDurationInMinutes),
                appointmentState = AppointmentStateEnum.Pendiente,
                notes = createTurnRequest.notes,
            };
            accountRepository.CreateAppointment(appointment);
        }

    }
}
