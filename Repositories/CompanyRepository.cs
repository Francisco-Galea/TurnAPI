using Dapper;
using Microsoft.Data.SqlClient;
using TurnApi.DTOs.Request;
using TurnApi.Repositories.Interface;

namespace TurnApi.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {

        private IConfiguration configuration { get; }
        private string connectionString { get; }

        public CompanyRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.connectionString = this.configuration["ConnectionStrings:SQLSERVER"];
        }

        public void CreateCompanyRequest(CreateCompanyRequest createCompanyRequest)
        {
            try
            {
                var connection = new SqlConnection(connectionString);
                var query = "INSERT INTO Companies CompanyName, AccountFounderId, Cuit, SocialName VALUES" +
                            "(@CompanyName, @AccountFounderId, @Cuit, @SocialName)";
                connection.Execute(query, new
                {
                    CompanyName = createCompanyRequest.companyName,
                    AccountFounderId = createCompanyRequest.founderAccountId,
                    Cuit = createCompanyRequest.cuit,
                    SocialName = createCompanyRequest.socialReason
                });
            }
            catch(Exception) 
            {
                throw new NotImplementedException();
            }
        }

    }
}
