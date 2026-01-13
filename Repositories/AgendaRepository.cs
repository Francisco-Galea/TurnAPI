using Dapper;
using Microsoft.Data.SqlClient;
using TurnApi.DTOs.Request;
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
                var query = "INSERT INTO Agendas (CompanyId, Name, Description, TurnDurationInMinutes) " +
                            "VALUES (@CompanyId, @Name, @Description, @TurnDurationInMinutes);";
                connection.Query(query, new
                {
                    CompanyId = createAgendaRequest.companyId,
                    Name = createAgendaRequest.name,
                    Description = createAgendaRequest.description,
                    TurnDurationInMinutes = createAgendaRequest.turnDurationInMinutes
                });
            }
            catch
            {

            }
        }

        public void CreateAgendaSchedule(AgendaSchedule agendaSchedule)
        {
            try
            {
                using var connection = new SqlConnection(connectionString);
                var query = "INSERT INTO AgendaSchedules (AgendaId, WorkableDay, TurnInit, TurnEnd) " +
                            "VALUES " +
                            "(@AgendaId, @WorkableDay, @TurnInit, @TurnEnd)";
                connection.Query(query, new
                {
                    AgendaId = agendaSchedule.agendaId,
                    WorkableDay = agendaSchedule.workableDay,
                    TurnInit = agendaSchedule.turnInit,
                    TurnEnd = agendaSchedule.turnEnd,
                });
            }
            catch
            {

            }
        }
    }
}
