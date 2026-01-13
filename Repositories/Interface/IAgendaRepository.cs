using TurnApi.DTOs.Request;
using TurnApi.Models;

namespace TurnApi.Repositories.Interface
{
    public interface IAgendaRepository
    {
        void CreateAgenda(CreateAgendaRequest createAgendaRequest);
        void CreateAgendaSchedule(AgendaSchedule agendaSchedule);
    }
}
