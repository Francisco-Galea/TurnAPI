using Microsoft.AspNetCore.Mvc;
using TurnApi.DTOs.Request;
using TurnApi.DTOs.Response;
using TurnApi.Models;
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

        [HttpPost("/CreateAgenda")]
        public void CreateAgenda([FromBody] CreateAgendaRequest createAgendaRequest)
        {
            agendaService.CreateAgenda(createAgendaRequest);
        }

        [HttpPost("/CreateAgendSchedule")]
        public void CreateAgendSchedule([FromBody] CreateAgendaScheduleRequest createAgendaScheduleRequest)
        {
            agendaService.CreateAgendaSchedule(createAgendaScheduleRequest);
        }
        
        [HttpGet("/GetAgenda")]
        public AgendaResponse GetAgenda(int agendaId,DateOnly dateSearched)
        {
            return agendaService.GetAgenda(agendaId, dateSearched);
        }

        [HttpPost("/AsignEmployeeToAgenda")]        
        public void AsignEmployeeToAgenda(int agendaId, int employeeId)
        {
            agendaService.AsignEmployeeToAgenda(agendaId, employeeId);
        }
        

    }
}
