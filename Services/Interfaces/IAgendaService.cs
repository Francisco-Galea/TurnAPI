using TurnApi.DTOs.Request;
using TurnApi.DTOs.Response;

namespace TurnApi.Services.Interfaces
{
    public interface IAgendaService
    {
        void CreateAgenda(CreateAgendaRequest createAgendaRequest);
        void CreateAgendaSchedule(CreateAgendaScheduleRequest createAgendaScheduleRequest);
        AgendaResponse GetSchedule(int agendaId, DateOnly dateSearched);
        AgendaResponse IsTurnAvailable(CreateTurnRequest createTurnRequest);
        AgendaResponse GetTurnsAvailable(int agendaId, DateOnly dateSearched, TimeOnly hourSearched);
    }
}
