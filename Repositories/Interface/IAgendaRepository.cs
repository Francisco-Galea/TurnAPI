using TurnApi.DTOs.Request;
using TurnApi.DTOs.Response;
using TurnApi.Models;

namespace TurnApi.Repositories.Interface
{
    public interface IAgendaRepository
    {
        void CreateAgenda(CreateAgendaRequest createAgendaRequest);
        void CreateAgendaSchedule(AgendaSchedule agendaSchedule);
        AgendaResponse GetSchedule(int agendaId, string dateSearched);
        List<Turn> GetTurns(int agendaId, DateOnly dateSearched);
    }
}
