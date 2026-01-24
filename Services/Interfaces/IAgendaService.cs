using TurnApi.DTOs.Request;
using TurnApi.DTOs.Response;

namespace TurnApi.Services.Interfaces
{
    public interface IAgendaService
    {
        void CreateAgenda(CreateAgendaRequest createAgendaRequest);
        void CreateAgendaSchedule(CreateAgendaScheduleRequest createAgendaScheduleRequest);
        AgendaResponse CreateShifts(int agendaId, DateOnly dateSearched);
        AgendaResponse IsAppointmentAvailable(CreateAppointmentRequest createAppointmentRequest);
        AgendaResponse GetAgenda(int agendaId, DateOnly dateSearched);
        void AsignEmployeeToAgenda(int agendaId, int employeeId);
    }
}
