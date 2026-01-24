using Dapper;
using Microsoft.Data.SqlClient;
using TurnApi.DTOs.Request;
using TurnApi.DTOs.Response;
using TurnApi.Models;
using TurnApi.Repositories.Interface;

namespace TurnApi.Repositories
{
    public class AgendaRepository : IAgendaRepository
    {

        private IConfiguration configuration { get; }
        private string connectionString { get; }

        public AgendaRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.connectionString = this.configuration["ConnectionStrings:SQLSERVER"];
        }

        public void CreateAgenda(CreateAgendaRequest createAgendaRequest)
        {
            try
            {
                using var connection = new SqlConnection(connectionString);
                var query = "INSERT INTO Agendas (CompanyId, Name, Description) " +
                            "VALUES (@CompanyId, @Name, @Description);";
                connection.Query(query, new
                {
                    CompanyId = createAgendaRequest.companyId,
                    Name = createAgendaRequest.name,
                    Description = createAgendaRequest.description,
                });
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public void CreateAgendaSchedule(AgendaSchedule agendaSchedule)
        {
            try
            {
                using var connection = new SqlConnection(connectionString);
                var query = "INSERT INTO AgendaSchedules (AgendaId, WorkableDay, AppointmentInit, AppointmentEnd, AppointmentDurationInMinutes) " +
                            "VALUES " +
                            "(@AgendaId, @WorkableDay, @AppointmentInit, @AppointmentEnd, @AppointmentDurationInMinutes)";
                connection.Query(query, new
                {
                    AgendaId = agendaSchedule.agendaId,
                    WorkableDay = agendaSchedule.workableDay,
                    AppointmentInit = agendaSchedule.appointmentInit,
                    AppointmentEnd = agendaSchedule.appointmentEnd,
                    AppointmentDurationInMinutes = agendaSchedule.appointmentDurationInMinutes
                });
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public AgendaResponse GetShifts(int agendaId, string dateSearched)
        {
            try
            {
                using var connection = new SqlConnection(connectionString);
                var query =
                    "SELECT a.Name, s.AppointmentDurationInMinutes, s.AppointmentInit, s.AppointmentEnd FROM AgendaSchedules s " +
                    "INNER JOIN Agendas a ON a.AgendaId = s.AgendaId " +
                    "WHERE s.WorkableDay = @DaySearched AND " +
                    "a.AgendaId = @AgendaId";
                return connection.QueryFirst<AgendaResponse>(query, new
                {
                    DaySearched = dateSearched,
                    AgendaId = agendaId
                });
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public List<Appointment> GetAppointments(int agendaId, DateOnly dateSearched)
        {
            try
            {
                using var connection = new SqlConnection(connectionString);
                var query = "SELECT AppointmentId, AppointmentInit, AppointmentEnd FROM Appointments " +
                            "WHERE AgendaId = @AgendaId AND " +
                            "AppointmentDate = @AppointmentDate";
                List<Appointment> appointments = connection.Query<Appointment>(query, new
                {
                    AgendaId = agendaId,
                    AppointmentDate = dateSearched
                }).ToList();
                return appointments;
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public void AsignEmployeeToAgenda(int agendaId, int employeeId)
        {
            try
            {
                using var connection = new SqlConnection(connectionString);
                var query = "INSERT INTO EmployeesAgendas (EmployeeId, AgendaId) VALUES" +
                            "(@EmployeeId, @AgendaId);";
                connection.Query(query, new
                {
                    EmployeeId = employeeId,
                    AgendaId = agendaId
                });
            }
            catch
            {
                throw new NotImplementedException();
            }
            
        }
    }
}
