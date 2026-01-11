using Dapper;
using Microsoft.Data.SqlClient;
using TurnApi.DTOs.Request;
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
    }
}
