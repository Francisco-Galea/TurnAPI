using TurnApi.DTOs.Request;
using TurnApi.DTOs.Response;
using TurnApi.Models;

namespace TurnApi.Repositories.Interface
{
    public interface IAgendaRepository
    {
        void CreateAgenda(CreateAgendaRequest createAgendaRequest);
        void CreateAgendaSchedule(AgendaSchedule agendaSchedule);
        AgendaResponse GetShifts(int agendaId, string dateSearched);
        List<Appointment> GetAppointments(int agendaId, DateOnly dateSearched);
        void AsignEmployeeToAgenda(int agendaId, int employeeId);
    }
}
