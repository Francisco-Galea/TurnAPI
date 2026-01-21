using TurnApi.DTOs.Request;
using TurnApi.DTOs.Response;
using TurnApi.Models;
using TurnApi.Repositories.Interface;
using TurnApi.Services.Interfaces;

namespace TurnApi.Services
{
    public class AgendaService : IAgendaService
    {

        private readonly IAgendaRepository agendaRepository;

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
                workableDay = createAgendaScheduleRequest.workableDay.ToUpper(),
                turnInit = createAgendaScheduleRequest.turnInit,
                turnEnd = createAgendaScheduleRequest.turnEnd
            };
            agendaRepository.CreateAgendaSchedule(agendaSchedule);
        }

        //Este va a ser traer el cronograma
        //ya filtrado por turnos hay ocupados y no ocupados
        public AgendaResponse GetSchedule(int agendaId, DateOnly dateSearched)
        {
            List<AvailableTurnResponse> list = new();
            string dayOfWeek = dateSearched.DayOfWeek.ToString().ToUpper();
            AgendaResponse agendaResponse = agendaRepository.GetSchedule(agendaId, dayOfWeek);
            for (int turnDuration = agendaResponse.turnDurationInMinutes; agendaResponse.turnInit < agendaResponse.turnEnd; agendaResponse.turnInit = agendaResponse.turnInit.AddMinutes(turnDuration))
            {
                AvailableTurnResponse availableTurnResponse = new()
                {
                    turnInit = agendaResponse.turnInit,
                    turnEnd = agendaResponse.turnInit.AddMinutes(turnDuration)
                };
                list.Add(availableTurnResponse);
                agendaResponse.availableTurns = list;
            }
            return agendaResponse;
        }

        public AgendaResponse GetTurnsAvailable(int agendaId, DateOnly dateSearched, TimeOnly hourSearched)
        {
            List<Turn> turns = agendaRepository.GetTurns(agendaId, dateSearched);
            AgendaResponse agendaSchedule = GetSchedule(agendaId, dateSearched);
            foreach(var timeBlock in agendaSchedule.availableTurns.ToList())
            {
                foreach(var turn in turns)
                {
                    if (turn.turnInit == hourSearched)
                    {
                        throw new Exception("Horario no disponible");
                    }
                    if(timeBlock.turnInit == turn.turnInit)
                    {
                        agendaSchedule.availableTurns.Remove(timeBlock);
                    }
                }
            }
            return agendaSchedule;
        }

        public AgendaResponse IsTurnAvailable(CreateTurnRequest createTurnRequest)
        {
            return GetTurnsAvailable(createTurnRequest.agendaId, createTurnRequest.turnDate, createTurnRequest.turnInit);
        }

    }
}
