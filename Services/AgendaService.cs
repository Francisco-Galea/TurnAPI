using TurnApi.DTOs.Request;
using TurnApi.Repositories.Interface;
using TurnApi.Services.Interfaces;

namespace TurnApi.Services
{
    public class AgendaService : IAgendaService
    {

        private IAgendaRepository agendaRepository;

        public AgendaService(IAgendaRepository agendaRepository)
        {
            this.agendaRepository = agendaRepository;
        }

        public void CreateAgenda(CreateAgendaRequest createAgendaRequest)
        {
            agendaRepository.CreateAgenda(createAgendaRequest);
        }
    }
}
