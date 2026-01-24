using TurnApi.DTOs.Request;

namespace TurnApi.Services.Interfaces
{
    public interface IAccountService
    {
        void CreateAccount(AccountCreationRequest accountRequest);
        void VerifyAccountAlreadyExist(AccountCreationRequest accountRequest);
        void CreateAppointment(CreateAppointmentRequest createAppointmentRequest);
    }
}
