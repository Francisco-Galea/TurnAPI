using TurnApi.DTOs.Request;

namespace TurnApi.Repositories.Interface
{
    public interface IAgendaRepository
    {
        void CreateAgenda(CreateAgendaRequest createAgendaRequest);
    }
}
