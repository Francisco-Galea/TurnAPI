using TurnApi.DTOs.Request;
using TurnApi.Models;
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

        public void CreateAgendaSchedule(CreateAgendaScheduleRequest createAgendaScheduleRequest)
        {
            AgendaSchedule agendaSchedule = new()
            {
                agendaId = createAgendaScheduleRequest.agendaId,
                workableDay = createAgendaScheduleRequest.workableDay,
                turnInit = TimeOnly.FromDateTime(createAgendaScheduleRequest.turnInit),
                turnEnd = TimeOnly.FromDateTime(createAgendaScheduleRequest.turnEnd)
            };
            agendaRepository.CreateAgendaSchedule(agendaSchedule);
        }
    }
}
