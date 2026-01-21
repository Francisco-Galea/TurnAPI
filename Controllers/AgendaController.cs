using Microsoft.AspNetCore.Mvc;
using TurnApi.DTOs.Request;
using TurnApi.DTOs.Response;
using TurnApi.Services.Interfaces;

namespace TurnApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendaController : ControllerBase
    {

        private IAgendaService agendaService;

        public AgendaController(IAgendaService agendaService)
        {
            this.agendaService = agendaService;
        }

        [HttpPost]
        public void CreateAgenda([FromBody] CreateAgendaRequest createAgendaRequest)
        {
            agendaService.CreateAgenda(createAgendaRequest);
        }

        [HttpPost("/CreateAgendSchedule")]
        public void CreateAgendSchedule([FromBody] CreateAgendaScheduleRequest createAgendaScheduleRequest)
        {
            agendaService.CreateAgendaSchedule(createAgendaScheduleRequest);
        }

        /*
        [HttpGet("/GetSchedule")]
        public AgendaResponse GetAvailableTurn(int agendaId,DateOnly dateSearched)
        {
            return agendaService.GetTurnsAvailable(agendaId, dateSearched);
        }
        */
    }
}
