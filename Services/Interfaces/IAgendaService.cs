using TurnApi.DTOs.Request;

namespace TurnApi.Services.Interfaces
{
    public interface IAgendaService
    {
        void CreateAgenda(CreateAgendaRequest createAgendaRequest);
        void CreateAgendaSchedule(CreateAgendaScheduleRequest createAgendaScheduleRequest);
    }
}
