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
                throw new NotImplementedException();
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
                throw new NotImplementedException();
            }
        }

        public AgendaResponse GetSchedule(int agendaId, string dateSearched)
        {
            try
            {
                using var connection = new SqlConnection(connectionString);
                var query =
                    "SELECT a.TurnDurationInMinutes, s.TurnInit, s.TurnEnd FROM AgendaSchedules s " +
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

        public List<Turn> GetTurns(int agendaId, DateOnly dateSearched)
        {
            try
            {
                using var connection = new SqlConnection(connectionString);
                var query = "SELECT TurnId, TurnInit, TurnEnd FROM Turns " +
                            "WHERE AgendaId = @AgendaId AND " +
                            "TurnDate = @TurnDate";
                List<Turn> turns = connection.Query<Turn>(query, new
                {
                    AgendaId = agendaId,
                    TurnDate = dateSearched
                }).ToList();
                return turns;
            }
            catch
            {
                throw new NotImplementedException();
            }
        }
    }
}
